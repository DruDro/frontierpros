using FrontierPros.Core.Domain.Catalog;
using FrontierPros.Core.Domain.Questions;
using FrontierPros.Core.Domain.Sources;
using FrontierPros.Core.Domain.Specialties;
using FrontierPros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Frontierpros.DataParser
{
	public enum PageType
	{
		Unknown,
		SetupStart,
		JobTypes,
		TravelPreferences,
		ServiceDetails,
		Prices
	}

	public class CategoryData
	{
		public int ID { get; set; }
		public string PK { get; set; }
		public string IDString { get; set; }
		public string Name { get; set; }
		public string Taxonym { get; set; }
		public string PluralTaxonym { get; set; }
		public double Popularity { get; set; }
		public double Rank { get; set; }
		public Dictionary<string,bool> NameTokens { get; set; }
	}

	public class CategoryComparer : IEqualityComparer<CategoryData>
	{
		public bool Equals(CategoryData cat1, CategoryData cat2)
		{
			return cat1.ID == cat2.ID;
		}

		public int GetHashCode(CategoryData obj)
		{
			return obj.ID;
		}
	}

	public static class ChromeDriverExtentions
	{
		public static void LoginAsPro(this ChromeDriver driver, string email, string password)
		{
			driver.Navigate().GoToUrl(@"https://www.thumbtack.com/login");
			var emailElement = driver.FindElement(By.XPath("//input[@type='email']"));
			emailElement.SendKeys(email);
			var passwordElement = driver.FindElement(By.XPath("//input[@type='password']"));
			passwordElement.SendKeys(password);
			var loginButton = driver.FindElement(By.XPath("//form//button[@type='submit']"));
			loginButton.Click();
		}

		public static PageType ParsePageType(this ChromeDriver driver)
		{
			PageType pageType = PageType.Unknown;

			if (driver.FindElements(By.XPath($"//div[@class='tp-title-5']//div[contains(text(),'Let’s set up your')]")).Count() > 0)
			{
				pageType = PageType.SetupStart;
			}
			else if (driver.FindElements(By.XPath("//div[@class='flex-auto']//div[contains(text(),'Job types')]")).Count() > 0)
			{
				pageType = PageType.JobTypes;
			}
			else if (driver.FindElements(By.XPath("//div[@class='flex-auto']//div[contains(text(),'Travel preferences')]")).Count() > 0)
			{
				pageType = PageType.TravelPreferences;
			}
			else if (driver.FindElements(By.XPath("//div[@class='flex-auto']//div[contains(text(),'Service details')]")).Count() > 0)
			{
				pageType = PageType.ServiceDetails;
			}
			else if (driver.FindElements(By.XPath("//div[@class='flex-auto']//div[contains(text(),'Prices')]")).Count() > 0)
			{
				pageType = PageType.Prices;
			}

			return pageType;
		}
	}

	class Program
	{
		public static string VConnectQuestionWrapperXPath = "//div[@class='question-wrapper'][@style= 'display:block' or @style='display:block;' or @style='display: block;' or @style= 'display: block' or @style='']";
		static void Main(string[] args)
		{
			//var zipCode = "10017";

			//var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			//var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			//builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
			MigrateQuestionsAndOptionsToProviderQuestionsAndOptions();
			#region Thumbtack 
			//using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
			//{
			//	driver.Manage().Window.Maximize();

			//	driver.LoginAsPro("yawecovaxi@host-info.com", "12345678");

			//	using (var db = new FrontierProsObjectContext(builder.Options))
			//	{
			//		var categoriesInfoRepository = new EfRepository<CategoryInfo>(db);
			//		//var questionsRepository = new EfRepository<Question>(db);
			//		//var completedCategories = questionsRepository.TableNoTracking.Select(q => q.CategoryInfoId).Distinct().ToArray();

			//		var categories = categoriesInfoRepository.TableNoTracking.OrderBy(c => c.Id).ToList();// Where(c => !completedCategories.Contains(c.Id)).OrderBy(c => c.Id).ToList();
			//		for (var i = 0; i < categories.Count; i++)
			//		{
			//			try
			//			{
			//				Console.WriteLine($"Index: {i}, CategoryId: {categories[i].Id}");
			//				ParseAddonsPerThumbtackCategory(driver, db, categories[i]);
			//			}
			//			catch
			//			{
			//			}
			//		}
			//	}
			//}
			#endregion

			#region VConnect
			//ParseVConnectGroupsAndCategories();
			//ParseVConnectQuestionsAndOptions();
			//ParseVconnectQuestionsAndOptionsRecursive();
			#endregion

			while (true)
			{
				Console.ReadKey();
			}
		}

        public static void ParseVConnectQuestionsAndOptions()
		{
			var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());

			using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
			{
				driver.Manage().Window.Maximize();

				using (var db = new FrontierProsObjectContext(builder.Options))
				{
					var groups = new List<ServiceCategory>();

					var groupSourceRepository = new EfRepository<ServiceCategorySource>(db);
                    var questionSourceRepository = new EfRepository<QuestionSource>(db);
                    var optionSourceRepository = new EfRepository<OptionSource>(db);

					var categoryGroupSourceRepository = new EfRepository<ServiceCategorySourceAndServiceInfoSource>(db);
					var categoriesInfoSourceRepository = new EfRepository<ServiceInfoSource>(db);
					var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
					driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
					var buttonNotNow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("wzrk-cancel")));
					buttonNotNow.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-category']")));

                    var categories = categoriesInfoSourceRepository.Table.Where(c => c.SourceType == SourceType.VConnect).ToList();
                    for(var i = 0; i < categories.Count(); i++)
                    {
                        var categoryInfo = categories[i];
                        var group = categoryGroupSourceRepository.Table.Include(cg => cg.ServiceCategory).First(cg => cg.ServiceInfoSourceId == categoryInfo.Id).ServiceCategory;

                        try
                        {
                            var groupElement = driver.FindElement(By.XPath($"//div[@class='each-business-category-name-text ng-binding'][normalize-space(text())='{group.Name}']"));
                            groupElement.Click();

                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-service']")));

                            var categoryElement = driver.FindElement(By.XPath($"//div[@class='each-business-service-name ng-binding'][normalize-space(text())='{categoryInfo.Name}']"));
                            categoryElement.Click();

                            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));

                            var getStartedButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Get Started')]")));
                            Console.WriteLine($"{i}. {categoryInfo.Id} {categoryInfo.Name} ({group.Name})");

                            var startMessage = driver.FindElement(By.XPath("//div[@class='question']"));

                            var pluralTaxonym = startMessage.Text
                                    .Replace("We will ask a few questions to connect you with the best", "")
                                    .Replace("you can trust", "").Trim();
                            categoryInfo.PluralTaxonym = pluralTaxonym;
                            categoriesInfoSourceRepository.Update(categoryInfo);

                            getStartedButton.Click();

                            var isStartQuestion = true;
							QuestionSource prevQuestion = null;

                            var questionWrapperXPath = "//div[@class='question-wrapper'][@style= 'display:block' or @style='display:block;' or @style='display: block;' or @style= 'display: block' or @style='']";

                            while (driver.FindElements(By.XPath($"{questionWrapperXPath}//span[contains(text(),'Finish')]")).Count() == 0)
                            {
                                var questionTitleElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//div[@class='question-title']"));
                                var heading = questionTitleElement.Text;
                                string placeholder = null;


                                var type = AnswerType.Custom;

                                if (driver.FindElements(By.XPath($"{questionWrapperXPath}//input[@type='checkbox']")).Count() > 0)
                                {
                                    type = AnswerType.MultiSelect;
                                }
                                else if (driver.FindElements(By.XPath($"{questionWrapperXPath}//input[@type='radio']")).Count() > 0)
                                {
                                    type = AnswerType.Select;
                                }
                                else if (driver.FindElements(By.XPath($"{questionWrapperXPath}//input[@type='number']")).Count() == 1 
									&& driver.FindElements(By.XPath($"{questionWrapperXPath}//input[@type='text']")).Count() == 0)
                                {
                                    type = AnswerType.Number;
                                    placeholder = driver
                                        .FindElement(By.XPath($"{questionWrapperXPath}//input[@type='number']"))
                                        .GetAttribute("placeholder");
                                }
                                else if (driver.FindElements(By.XPath($"{questionWrapperXPath}//input[@type='text']")).Count() == 1)
                                {
									var inputElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//input[@type='text']"));
									var dataType = inputElement.GetAttribute("data-type");

									type = dataType == "date" ? AnswerType.Date : AnswerType.Text;

                                    placeholder = inputElement.GetAttribute("placeholder");
                                }
                                else if (driver.FindElements(By.XPath($"{questionWrapperXPath}//textarea")).Count() == 1)
                                {
                                    type = AnswerType.TextArea;
                                    placeholder = driver
                                        .FindElement(By.XPath($"{questionWrapperXPath}//textarea"))
                                        .GetAttribute("placeholder");
                                }
                                else if (driver.FindElements(By.XPath($"{questionWrapperXPath}//select")).Count()== 1)
                                {
                                    type = AnswerType.DropDown;
                                }

                                Console.WriteLine();
                                Console.WriteLine($"{heading.ToString()} ({type.ToString()})");

                                var options = new List<OptionSource>();

                                if (type == AnswerType.Select || type == AnswerType.MultiSelect)
                                {
                                    var spanElements = driver.FindElements(By.XPath($"{questionWrapperXPath}//label//span"));
                                    for (var optionIndex = 0; optionIndex < spanElements.Count(); optionIndex++)
                                    {
                                        var text = spanElements[optionIndex].Text;
                                        
                                        var option = new OptionSource()
                                        {
                                            Text = text,
                                            Order = optionIndex
                                        };

                                        if(!options.Any(o=>o.Text == text))
                                        {
                                            options.Add(option);
                                            Console.WriteLine("\t" + text);
                                        }
                                    }
                                }
								else if(type == AnswerType.DropDown)
                                {
                                    var optionsElements = driver.FindElements(By.XPath($"{questionWrapperXPath}//select//option"));
                                    for (var optionIndex = 0; optionIndex < optionsElements.Count(); optionIndex++)
                                    {
                                        var text = optionsElements[optionIndex].Text;

                                        var option = new OptionSource()
                                        {
                                            Text = text,
                                            Order = optionIndex
                                        };

                                        if (!options.Any(o => o.Text == text))
                                        {
                                            options.Add(option);
                                            Console.WriteLine("\t" + text);
                                        }
                                    }
                                }

                                var question = questionSourceRepository.Table.FirstOrDefault(q => q.ServiceInfoSourceId == categoryInfo.Id && q.Heading == heading) ?? new QuestionSource()
                                {
									ServiceInfoSourceId = categoryInfo.Id,
                                    Heading = heading,
                                    IsStartQuestion = isStartQuestion,
                                    Placeholder = placeholder,
                                    Type = type
                                };

                                if (question.Id == 0)
                                {
									questionSourceRepository.Insert(question);
                                    if (prevQuestion != null)
                                    {
                                        prevQuestion.NextQuestionSourceId = question.Id;
                                        questionSourceRepository.Update(prevQuestion);
                                    }

                                    prevQuestion = question;

                                    if (options.Count > 0)
                                    {
                                        foreach (var option in options)
                                        {
                                            option.QuestionSourceId = question.Id;
                                            optionSourceRepository.Insert(option);
                                        }
                                    }
                                }


                                var nextBtn = driver.FindElement(By.XPath($"{questionWrapperXPath}//span[contains(text(),'Next')]"));
                                nextBtn.Click();

                                Task.Delay(1000).GetAwaiter().GetResult();

                                var newHeading = driver.FindElement(By.XPath($"{questionWrapperXPath}//div[@class='question-title']")).Text;
                                if (heading == newHeading)
                                {
                                    question.IsRequired = true;
                                    questionSourceRepository.Update(question);

                                    switch (type)
                                    {
                                        case AnswerType.MultiSelect:
                                        case AnswerType.Select:
                                            var spanElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//label//span"));
                                            spanElement.Click();
                                            break;
                                        case AnswerType.Number:
                                            var inputElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//input[@type='number']"));
                                            inputElement.SendKeys("1");
                                            break;
                                        case AnswerType.TextArea:
                                            var textAreaElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//textarea"));
                                            textAreaElement.SendKeys("Some description");
                                            break;
                                        case AnswerType.DropDown:
                                            var selectElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//select"));
                                            selectElement.Click();
                                            selectElement.SendKeys(Keys.ArrowDown);
                                            selectElement.SendKeys(Keys.Enter);
                                            break;
                                        case AnswerType.Text:
                                            var textElement = driver.FindElement(By.XPath($"{questionWrapperXPath}//input[@type='text']"));
                                            textElement.SendKeys("Some description");
                                            break;
										case AnswerType.Date:
											var dayOfMonth = DateTime.UtcNow.Day;
											var spanToSelect = driver.FindElement(By.XPath($"{questionWrapperXPath}//span[contains(text(),'{dayOfMonth}')]"));
											spanToSelect.Click();
											break;
                                        default:
                                            break;
                                    }
                                }

                                Task.Delay(2000).GetAwaiter().GetResult();

                                newHeading = driver.FindElement(By.XPath($"{questionWrapperXPath}//div[@class='question-title']")).Text;
                                if (heading == newHeading)
                                {
                                    try
                                    {
                                        nextBtn.Click();
                                    }
                                    catch
                                    {

                                    }
                                }
								isStartQuestion = false;
                            }
                        }
                        catch
                        {
                             Console.WriteLine($"{i}. {categoryInfo.Id}{categoryInfo.Name} ({group.Name}) - No Questions");
                        }

                        driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
                    }
				}
			}
		}
		

		public static void ParseVconnectQuestionsAndOptionsRecursive()
		{
			var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());

			using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
			{
				driver.Manage().Window.Maximize();

				using (var db = new FrontierProsObjectContext(builder.Options))
				{
					var groupSourceRepository = new EfRepository<ServiceCategorySource>(db);
					var questionSourceRepository = new EfRepository<QuestionSource>(db);
					var optionSourceRepository = new EfRepository<OptionSource>(db);
					var categoryGroupSourceRepository = new EfRepository<ServiceCategorySourceAndServiceInfoSource>(db);
					var categoryInfoSourceRepository = new EfRepository<ServiceInfoSource>(db);

					var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
					driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
					var buttonNotNow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("wzrk-cancel")));
					buttonNotNow.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-category']")));

					var categoryIds = new List<int>() {
						474,581,582
					};/* questionRepository.Table.Include(q => q.CategoryInfo)
						.Where(q => q.CategoryInfo.SourceType == SourceType.VConnect)
						.Select(q => q.CategoryInfoId).ToList();*/

					var categories = categoryInfoSourceRepository.Table.Where(c => c.SourceType == SourceType.VConnect && categoryIds.Contains(c.Id)).ToList();
					for (var i = 0; i < categories.Count(); i++)
					{
						var categoryInfo = categories[i];
						
						var group = categoryGroupSourceRepository.Table.Include(cg => cg.ServiceCategory).First(cg => cg.ServiceInfoSourceId == categoryInfo.Id).ServiceCategory;

						try
						{
							var groupElement = driver.FindElement(By.XPath($"//div[@class='each-business-category-name-text ng-binding'][normalize-space(text())='{group.Name}']"));
							groupElement.Click();

							wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-service']")));

							var categoryElement = driver.FindElement(By.XPath($"//div[@class='each-business-service-name ng-binding'][normalize-space(text())='{categoryInfo.Name}']"));
							categoryElement.Click();

							driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));

							var getStartedButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Get Started')]")));
							Console.WriteLine($"{i}. {categoryInfo.Id} {categoryInfo.Name} ({group.Name})");

							var startMessage = driver.FindElement(By.XPath("//div[@class='question']"));

							var pluralTaxonym = startMessage.Text
									.Replace("We will ask a few questions to connect you with the best", "")
									.Replace("you can trust", "").Trim();
							categoryInfo.PluralTaxonym = pluralTaxonym;
							categoryInfoSourceRepository.Update(categoryInfo);

							getStartedButton.Click();

							ParseQuestion(driver, questionSourceRepository, optionSourceRepository, categoryInfo);
						}
						catch
						{
							Console.WriteLine($"{i}. {categoryInfo.Id}{categoryInfo.Name} ({group.Name}) - No Questions");
						}

						driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
					}
				}
			}
		}

		public static void ParseQuestion(ChromeDriver driver, 
										EfRepository<QuestionSource> questionRepository, 
										EfRepository<OptionSource> optionRepository,
										ServiceInfoSource categoryInfo,
										QuestionSource prevQuestion = null,
										OptionSource selectedOption = null,
										bool isStartQuestion = true)
		{
			if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//span[contains(text(),'Finish')]")).Count() != 0) {
				ClickPrevButton(driver);
				return;
			}

			var heading = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//div[@class='question-title']")).Text;

			var currentQuestion = questionRepository.Table.FirstOrDefault(q => q.ServiceInfoSourceId == categoryInfo.Id && q.Heading == heading);
			if (currentQuestion == null)
			{
				currentQuestion = new QuestionSource()
				{
					ServiceInfoSourceId = categoryInfo.Id,
					Heading = heading,
					IsStartQuestion = isStartQuestion
				};

				FillQuestionData(driver, currentQuestion);
				questionRepository.Insert(currentQuestion);

				var options = GetQuestionOptions(driver, currentQuestion);
				if (options.Count > 0)
				{
					foreach (var option in options)
					{
						option.QuestionSourceId = currentQuestion.Id;
						optionRepository.Insert(option);
					}
				}
			}

			if (prevQuestion != null && prevQuestion.Type != AnswerType.Select)
			{
				prevQuestion.NextQuestionSourceId = currentQuestion.Id;
				questionRepository.Update(prevQuestion);
			}

			if (selectedOption != null && selectedOption.QuestionSourceId != currentQuestion.Id)
			{
				selectedOption.NextQuestionSourceId = currentQuestion.Id;
				optionRepository.Update(selectedOption);
			}

			AnswerOnQuestionVConnect(driver, currentQuestion, selectTypeAction: () => {
				var questionOptions = optionRepository.Table.Where(o => o.QuestionSourceId == currentQuestion.Id && !o.NextQuestionSourceId.HasValue).ToList();
				foreach (var option in questionOptions)
				{
					var optionElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//div[@class='options']//span[normalize-space(text())=\"{option.Text}\"]"));
					optionElement.Click();

					Console.WriteLine($"+ {option.Text}");

					ClickNextButtonIfNeeded(driver, currentQuestion.Heading);

					ParseQuestion(driver, questionRepository, optionRepository, categoryInfo, currentQuestion, option, false);
				}
			});

			if(currentQuestion.Type != AnswerType.Select && !currentQuestion.NextQuestionSourceId.HasValue)
			{
				ClickNextButtonIfNeeded(driver, currentQuestion.Heading);
				ParseQuestion(driver, questionRepository, optionRepository, categoryInfo, currentQuestion, null, false);
			}

			ClickPrevButton(driver);
		}

		public static List<OptionSource> GetQuestionOptions(ChromeDriver driver, QuestionSource question)
		{
			var options = new List<OptionSource>();

			if (question.Type == AnswerType.Select || question.Type == AnswerType.MultiSelect)
			{
				var spanElements = driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//label//span"));
				for (var optionIndex = 0; optionIndex < spanElements.Count(); optionIndex++)
				{
					var text = spanElements[optionIndex].Text;

					var option = new OptionSource()
					{
						Text = text,
						Order = optionIndex
					};

					if (!options.Any(o => o.Text == text))
					{
						options.Add(option);
						Console.WriteLine("\t" + text);
					}
				}
			}
			else if (question.Type == AnswerType.DropDown)
			{
				var optionsElements = driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//select//option"));
				for (var optionIndex = 0; optionIndex < optionsElements.Count(); optionIndex++)
				{
					var text = optionsElements[optionIndex].Text;
					if (!string.IsNullOrEmpty(text))
					{
						var option = new OptionSource()
						{
							Text = text,
							Order = optionIndex
						};
						if (!options.Any(o => o.Text == text))
						{
							options.Add(option);
							Console.WriteLine("\t" + text);
						}
					}
				}
			}
			return options;
		}

		public static AnswerType GetQuestionType(ChromeDriver driver)
		{
			var type = AnswerType.Custom;

			if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='checkbox']")).Count() > 0)
			{
				type = AnswerType.MultiSelect;
			}
			else if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='radio']")).Count() > 0)
			{
				type = AnswerType.Select;
			}
			else if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='number']")).Count() == 1
				&& driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='text']")).Count() == 0)
			{
				type = AnswerType.Number;
			}
			else if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='text']")).Count() == 1)
			{
				var inputElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='text']"));
				var dataType = inputElement.GetAttribute("data-type");

				type = dataType == "date" ? AnswerType.Date : AnswerType.Text;
			}
			else if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//textarea")).Count() == 1)
			{
				type = AnswerType.TextArea;

			}
			else if (driver.FindElements(By.XPath($"{VConnectQuestionWrapperXPath}//select")).Count() == 1)
			{
				type = AnswerType.DropDown;
			}
			return type;
		}

		public static void FillQuestionData(ChromeDriver driver, QuestionSource question)
		{
			question.Type = GetQuestionType(driver);

			switch (question.Type)
			{
				case AnswerType.MultiSelect:
					break;
				case AnswerType.Select:
					break;
				case AnswerType.Number:
					question.Placeholder = driver
					.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='number']"))
					.GetAttribute("placeholder");
					break;
				case AnswerType.TextArea:
					question.Placeholder = driver
					.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//textarea"))
					.GetAttribute("placeholder");
					break;
				case AnswerType.DropDown:
					break;
				case AnswerType.Text:
				case AnswerType.Date:
					var inputElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='text']"));
					question.Placeholder = inputElement.GetAttribute("placeholder");
					break;
				default:
					break;
			}
			Console.WriteLine();
			Console.WriteLine($"{question.Heading.ToString()} ({question.Type.ToString()})");
		}

		public static void AnswerOnQuestionVConnect(ChromeDriver driver, QuestionSource question, Action selectTypeAction = null)
		{
			//Answer on question
			switch (question.Type)
			{
				case AnswerType.MultiSelect:
					var spanElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//label//span"));
					spanElement.Click();
					break;
				case AnswerType.Select:
					if(selectTypeAction != null)
					{
						selectTypeAction.Invoke();
					}
					else
					{
						var spanElement2 = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//label//span"));
						spanElement2.Click();
					}
					break;
				case AnswerType.Number:
					var inputElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='number']"));
					inputElement.SendKeys("1");
					break;
				case AnswerType.TextArea:
					var textAreaElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//textarea"));
					if (string.IsNullOrEmpty(textAreaElement.GetAttribute("value")))
					{
						textAreaElement.SendKeys("Some description");
					}
					break;
				case AnswerType.DropDown:
					var selectElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//select"));
					selectElement.Click();
					selectElement.SendKeys(Keys.ArrowDown);
					selectElement.SendKeys(Keys.Enter);
					break;
				case AnswerType.Text:
					var textElement = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//input[@type='text']"));
					textElement.SendKeys("Some description");
					break;
				case AnswerType.Date:
					var dayOfMonth = DateTime.UtcNow.Day;
					var spanToSelect = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//span[contains(text(),'{dayOfMonth}')]"));
					spanToSelect.Click();
					break;
				default:
					break;
			}
		}

		public static void ClickNextButtonIfNeeded(ChromeDriver driver, string currentQuestionHeading)
		{
			Task.Delay(1000).GetAwaiter().GetResult();

			var newHeading = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//div[@class='question-title']")).Text;
			if (currentQuestionHeading == newHeading)
			{
				try
				{
					var nextBtn = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//span[contains(text(),'Next')]"));
					nextBtn.Click();
				}
				catch
				{

				}
			}

			Task.Delay(1000).GetAwaiter().GetResult();
		}

		public static void ClickPrevButton(ChromeDriver driver)
		{
			Task.Delay(1000).GetAwaiter().GetResult();
			try
			{
				var prevBtn = driver.FindElement(By.XPath($"{VConnectQuestionWrapperXPath}//span[contains(text(),'Previous')]"));
				prevBtn.Click();
			}
			catch
			{

			}
			Task.Delay(1000).GetAwaiter().GetResult();
		}

		public static void ParseVConnectGroupsAndCategories()
		{
			var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());

			using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
			{
				driver.Manage().Window.Maximize();

				using (var db = new FrontierProsObjectContext(builder.Options))
				{
					var groups = new List<ServiceCategorySource>();

					var groupSourceRepository = new EfRepository<ServiceCategorySource>(db);
					var categoryGroupSourceRepository = new EfRepository<ServiceCategorySourceAndServiceInfoSource>(db);
					var categoryInfoSourceRepository = new EfRepository<ServiceInfoSource>(db);
					var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
					driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
					var buttonNotNow = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("wzrk-cancel")));
					buttonNotNow.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-category']")));
					var groupElements = driver.FindElements(By.XPath("//div[@class='each-business-category-name-text ng-binding']"));
					foreach (var groupElement in groupElements)
					{
						var groupName = groupElement.Text;
						var group = groupSourceRepository.Table.FirstOrDefault(g => g.Name == groupName);
						if (group == null)
						{
							group = new ServiceCategorySource()
							{
								Name = groupName,
								SourceType = SourceType.VConnect,
								CreatedOnUtc = DateTime.UtcNow,
								UpdatedOnUtc = DateTime.UtcNow,
								Published = true
							};
							groupSourceRepository.Insert(group);
						}

						groups.Add(group);

						Console.WriteLine(group.Name);
					}

					Console.WriteLine("\n\nAll groups parsed successfully\n\n");

					foreach (var group in groups)
					{
						if (group.Name == "Others") continue;

						var groupElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//div[@class='each-business-category-name-text ng-binding'][contains(text(),'{group.Name}')]")));
						groupElement.Click();
						Console.WriteLine(group.Name);

						wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='each-business-service']")));
						var categoryElements = driver.FindElements(By.XPath("//div[@class='each-business-service-name ng-binding']"));
						foreach (var categoryElement in categoryElements)
						{
							var categoryName = categoryElement.Text;
							var categoryInfo = categoryInfoSourceRepository.Table.FirstOrDefault(c => c.SourceType == SourceType.VConnect && c.Name == categoryName);
							if (categoryInfo == null)
							{
								//var category = new Category()
								//{
								//	Name = categoryName,
								//	Description = null,
								//	CategoryTemplateId = 1,
								//	MetaKeywords = null,
								//	MetaDescription = null,
								//	MetaTitle = null,
								//	ParentCategoryId = 0,
								//	PictureId = 0,
								//	PageSize = 6,
								//	AllowCustomersToSelectPageSize = true,
								//	PageSizeOptions = "6, 3, 9",
								//	PriceRanges = null,
								//	ShowOnHomePage = false,
								//	IncludeInTopMenu = true,
								//	SubjectToAcl = false,
								//	LimitedToStores = false,
								//	Published = true,
								//	Deleted = false,
								//	DisplayOrder = 0,
								//	CreatedOnUtc = DateTime.UtcNow,
								//	UpdatedOnUtc = DateTime.UtcNow
								//};

								//db.Add(category);
								//db.SaveChanges();

								categoryInfo = new ServiceInfoSource()
								{
									Name = categoryName,
									//CategoryId = category.Id,
									SourceType = SourceType.VConnect,
									Published = true,
									CreatedOnUtc = DateTime.UtcNow,
									UpdatedOnUtc = DateTime.UtcNow
								};

								db.Add(categoryInfo);
								db.SaveChanges();
							}

							if (!categoryGroupSourceRepository.Table.Any(cg => cg.ServiceInfoSourceId == categoryInfo.Id && cg.ServiceCategorySourceId == group.Id))
							{
								categoryGroupSourceRepository.Insert(new ServiceCategorySourceAndServiceInfoSource() { ServiceInfoSourceId = categoryInfo.Id, ServiceCategorySourceId = group.Id });
							}

							Console.WriteLine("\t" + categoryName);
						}
						driver.Navigate().GoToUrl(@"https://www.vconnect.com/hire-local-service-professionals-nigeria");
					}
				}
			}
		}

		public static void MigrateQuestionsAndOptionsToProviderQuestionsAndOptions()
		{
			var builder = new DbContextOptionsBuilder<FrontierProsObjectContext>();
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());

			using (var db = new FrontierProsObjectContext(builder.Options))
			{
				var serviceInfoSourceRepository = new EfRepository<ServiceInfoSource>(db);
				var questionSourceRepository = new EfRepository<QuestionSource>(db);

				var serviceInfoSources = serviceInfoSourceRepository.TableNoTracking.OrderBy(c => c.Id).ToList();
				for (var i = 0; i < serviceInfoSources.Count; i++)
				{
					var serviceInfoSource = serviceInfoSources[i];
					Console.WriteLine($"{i}: {serviceInfoSource.Name}");
					var questions = questionSourceRepository.TableNoTracking.Include(q => q.Options)
						.Where(c => c.ServiceInfoSourceId == serviceInfoSource.Id && (c.Type == AnswerType.MultiSelect || c.Type == AnswerType.Select))
						.OrderBy(q => q.Id)
						.ToList();

					for (var index = 0; index < questions.Count(); index++)
					{
						var question = questions[index];
						var options = serviceInfoSource.SourceType == SourceType.Thumbtack ?
							question.Options.Where(o => !string.IsNullOrEmpty(o.Text) && o.Text.IndexOf("recommended") < 0).ToList()
							: question.Options.Where(o => !string.IsNullOrEmpty(o.Text)).ToList();

						if (options.Count() > 0)
						{
							question.ProviderHeading = question.Heading;
							question.ProviderSubHeading = question.SubHeading;
							question.IsProviderQuestion = true;
							db.Update(question);
							db.SaveChanges();

							for (var optionIndex = 0; optionIndex < options.Count(); optionIndex++)
							{
								var option = options[optionIndex];
								option.ProviderText = option.Text;

								db.Update(option);
								db.SaveChanges();
							}
						}
					}
				}
			}
			
		}

		#region Thumbtack
		public static void ParseThumbtackCategoryGroups(ChromeDriver driver, FrontierProsObjectContext db)
		{
			var categoryInfoSourceRepository = new EfRepository<ServiceInfoSource>(db);

			driver.Navigate().GoToUrl(@"https://www.thumbtack.com/more-services");

			var groupSections = driver.FindElements(By.XPath("//div[@class='tp-col tp-col--12 tp-col--md-8']//div[@style='margin-top: -90px;padding-top: 90px;']"));
			for (var groupIndex = 0; groupIndex < groupSections.Count; groupIndex++)
			{
				var groupSection = groupSections[groupIndex];

				var sectionHeader = groupSection.FindElement(By.TagName("h3"));
				var sectionName = sectionHeader.Text;
				Console.WriteLine(sectionName);

				var group = new ServiceCategorySource()
				{
					Name = sectionName,
					SourceType = SourceType.Thumbtack,
					CreatedOnUtc = DateTime.UtcNow,
					UpdatedOnUtc = DateTime.UtcNow
				};

				db.Add(group);
				db.SaveChanges();

				var categoryBlocks = groupSection.FindElements(By.TagName("a"));
				for (var categoryIndex = 0; categoryIndex < categoryBlocks.Count; categoryIndex++)
				{
					var categoryName = categoryBlocks[categoryIndex].Text;
					Console.WriteLine($"- {categoryName}");

					var category = categoryInfoSourceRepository.TableNoTracking.FirstOrDefault(c => c.Name == categoryName);
					if(category != null)
					{
						var categoryGroup = new ServiceCategorySourceAndServiceInfoSource()
						{
							ServiceInfoSourceId = category.Id,
							ServiceCategorySourceId = group.Id
						};

						db.Add(categoryGroup);
					}
				}
				db.SaveChanges();
			}
		}

		public static void ParseThumbtackCategories()
		{
			//Category Parser for thumbtack.com website

			var comparer = new CategoryComparer();
			var list = new List<CategoryData>();

			using (HttpClient client = new HttpClient())
			{
				var alpha = "abcdefghijklmnopqrstuvwxyz";

				for (int i = 0; i < alpha.Length; i++)
				{
					for (int j = 0; j < alpha.Length; j++)
					{
						for (int k = 0; k < alpha.Length; k++)
						{
							for (int l = 0; l < alpha.Length; l++)
							{
								var query = $"{alpha[i]}{alpha[j]}{alpha[k]}{alpha[l]}";
								Console.WriteLine(query);
								var response = client.GetAsync($"https://hercule.thumbtack.com/search?query={query}&prefix=1&limit=10000&v=0&includeTest=false").GetAwaiter().GetResult();

								var currentJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
								var currentList = JsonConvert.DeserializeObject<List<CategoryData>>(currentJson);

								if (currentList?.Count > 0)
								{
									list.AddRange(currentList);
									list = list.Distinct(comparer).ToList();
								}
							}
						}
					}
				}
			}
			Console.WriteLine(list.Count());
			var json = JsonConvert.SerializeObject(list.OrderBy(c => c.ID).ToList());
			File.WriteAllText("categories.txt", json);
		}

		public static void AddThumbtackCategory(FrontierProsObjectContext db, CategoryData categoryData)
		{

			var nameTokenRepository = new EfRepository<NameTokenSource>(db);

			var nameTokens = categoryData.NameTokens.Select(n => n.Key).Distinct().Select(n => new NameTokenSource()
			{
				Name = n
			}).ToList();

			foreach(var nameToken in nameTokens)
			{
				if(!nameTokenRepository.TableNoTracking.Any(token => token.Name == nameToken.Name))
				{
					db.Add(nameToken);
				}
			}

			db.SaveChanges();

			//var category = new Category()
			//{
			//	Name = categoryData.Name,
			//	Description = null,
			//	CategoryTemplateId = 1,
			//	MetaKeywords = null,
			//	MetaDescription = null,
			//	MetaTitle = null,
			//	ParentCategoryId = 0,
			//	PictureId = 0,
			//	PageSize = 6,
			//	AllowCustomersToSelectPageSize = true,
			//	PageSizeOptions = "6, 3, 9",
			//	PriceRanges = null,
			//	ShowOnHomePage = false,
			//	IncludeInTopMenu = true,
			//	SubjectToAcl = false,
			//	LimitedToStores = false,
			//	Published = true,
			//	Deleted = false,
			//	DisplayOrder = 0,
			//	CreatedOnUtc = DateTime.UtcNow,
			//	UpdatedOnUtc = DateTime.UtcNow
			//};

			//db.Add(category);
			//db.SaveChanges();

			var categoryInfo = new ServiceInfoSource()
			{
				IDString = categoryData.IDString,
				Name = categoryData.Name,
				//CategoryId = category.Id,
				PK = categoryData.PK,
				PluralTaxonym = categoryData.PluralTaxonym,
				Taxonym = categoryData.Taxonym,
				Popularity = categoryData.Popularity,
				Rank = categoryData.Rank,
				SourceType = SourceType.Thumbtack
			};

			db.Add(categoryInfo);
			db.SaveChanges();

			foreach (var nameTokenData in categoryData.NameTokens)
			{
				var nameToken = nameTokenRepository.TableNoTracking.FirstOrDefault(n => n.Name == nameTokenData.Key);
				if (nameToken != null)
				{
					var categoryNameToken = new ServiceInfoSourceAndNameTokenSource()
					{
						NameTokenSourceId = nameToken.Id,
						ServiceInfoSourceId = categoryInfo.Id,
						Enabled = nameTokenData.Value
					};

					db.Add(categoryNameToken);
					db.SaveChanges();
				}
			}
			Console.WriteLine($"{categoryInfo.Id} {categoryData.Name}");
		}

		public static void AddThumbtackCategories(FrontierProsObjectContext db)
		{
			
			var nameTokenRepository = new EfRepository<NameTokenSource>(db);

			var currentJson = File.ReadAllText("categoriesTemp473.txt");
			var categoryDataList = JsonConvert.DeserializeObject<List<CategoryData>>(currentJson);

			var nameTokens = categoryDataList.SelectMany(c => c.NameTokens).Select(n => n.Key).Distinct().Select(n => new NameTokenSource()
			{
				Name = n
			}).ToList();

			db.AddRange(nameTokens);
			db.SaveChanges();

			foreach (var categoryData in categoryDataList)
			{
				//var category = new Category()
				//{
				//	Name = categoryData.Name,
				//	Description = null,
				//	CategoryTemplateId = 1,
				//	MetaKeywords = null,
				//	MetaDescription = null,
				//	MetaTitle = null,
				//	ParentCategoryId = 0,
				//	PictureId = 0,
				//	PageSize = 6,
				//	AllowCustomersToSelectPageSize = true,
				//	PageSizeOptions = "6, 3, 9",
				//	PriceRanges = null,
				//	ShowOnHomePage = false,
				//	IncludeInTopMenu = true,
				//	SubjectToAcl = false,
				//	LimitedToStores = false,
				//	Published = true,
				//	Deleted = false,
				//	DisplayOrder = 0,
				//	CreatedOnUtc = DateTime.UtcNow,
				//	UpdatedOnUtc = DateTime.UtcNow
				//};

				//db.Add(category);
				//db.SaveChanges();

				var categoryInfo = new ServiceInfoSource()
				{
					IDString = categoryData.IDString,
					Name = categoryData.Name,
					//CategoryId = category.Id,
					PK = categoryData.PK,
					PluralTaxonym = categoryData.PluralTaxonym,
					Taxonym = categoryData.Taxonym,
					Popularity = categoryData.Popularity,
					Rank = categoryData.Rank,
					SourceType = SourceType.Thumbtack
				};

				db.Add(categoryInfo);
				db.SaveChanges();

				foreach (var nameTokenData in categoryData.NameTokens)
				{
					var nameToken = nameTokenRepository.TableNoTracking.FirstOrDefault(n => n.Name == nameTokenData.Key);
					if (nameToken != null)
					{
						var categoryNameToken = new ServiceInfoSourceAndNameTokenSource()
						{
							NameTokenSourceId = nameToken.Id,
							ServiceInfoSourceId = categoryInfo.Id,
							Enabled = nameTokenData.Value
						};

						db.Add(categoryNameToken);
						db.SaveChanges();
					}
				}
				Console.WriteLine($"{categoryInfo.Id} {categoryData.Name}");
				
			}
		}

		public static void ParseQuestionsPerThumbtackCategory(ChromeDriver driver, FrontierProsObjectContext db, ServiceInfoSource categoryInfo, string zipCode)
		{
			var specialtySourceRepository = new EfRepository<SpecialtySource>(db);
			var optionRepository = new EfRepository<OptionSource>(db);
			var questionRepository = new EfRepository<QuestionSource>(db);

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));

			driver.Navigate().GoToUrl(@"https://www.thumbtack.com");

			var formElement = driver.FindElement(By.Id("uniqueId3"));

			var zipCodeEl = formElement.FindElement(By.XPath("//input[@placeholder='Zip code']"));
			zipCodeEl.Clear();
			zipCodeEl.Click();
			zipCodeEl.SendKeys(zipCode);

			var searchInputEl = formElement.FindElement(By.XPath("//input[@data-test='search-input']"));
			searchInputEl.SendKeys(categoryInfo.Name);

			Task.Delay(2000).GetAwaiter().GetResult();

			var button = formElement.FindElement(By.XPath("//form[@id='uniqueId3']//button[@type='submit']"));
			button.Click();
			try
			{
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'View Profile')]")));
			}
			catch
			{
				var searchInputElement = driver.FindElement(By.XPath("//form[@id='uniqueId3']//input[@data-test='search-input']"));
			}
			

			var searchInputEl2 = driver.FindElement(By.XPath("//form[@id='uniqueId3']//input[@data-test='search-input']"));
			var value = searchInputEl2.GetAttribute("value");
			if(value != categoryInfo.Name)
			{
				var tryCount = 5;
				while(tryCount != 0 && value != categoryInfo.Name)
				{
					searchInputEl2.SendKeys(Keys.Control + "a");
					searchInputEl2.SendKeys(Keys.Delete);
					searchInputEl2.SendKeys(categoryInfo.Name);

					var button2 = driver.FindElement(By.XPath("//form[@id='uniqueId3']//button[@data-test='search-button']"));
					button2.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'View Profile')]")));

					searchInputEl2 = driver.FindElement(By.XPath("//form[@id='uniqueId3']//input[@data-test='search-input']"));
					value = searchInputEl2.GetAttribute("value");

					tryCount--;
				}
			}

			var viewProfileButtonElement = driver.FindElement(By.XPath("//span[contains(text(),'View Profile')]"));
			viewProfileButtonElement.Click();


			//Adding specialities for caterory and settings specialities for options
			var optionsWithSpecialities = new Dictionary<string, int>();
			try
			{
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button//span//span[contains(text(),'Check availability')]")));

				try
				{
					var showMoreButton = driver.FindElement(By.XPath("//section[@id='stickynav-services']//p//button[contains(text(), 'Show more')]"));
					showMoreButton.Click();
				}
				catch { }

				var specialtiesBlocks = driver.FindElements(By.XPath("//section[@id='stickynav-services']//div[@class='mt2']"));
				for (var specIndex = 0; specIndex < specialtiesBlocks.Count; specIndex++)
				{
					var headingElement = specialtiesBlocks[specIndex].FindElement(By.TagName("p"));
					var heading = headingElement.Text;
					var specialty = specialtySourceRepository.TableNoTracking.FirstOrDefault(s => s.Heading == heading && s.ServiceInfoSourceId == categoryInfo.Id) ?? new SpecialtySource()
					{
						Heading = heading,
						Order = specIndex,
						ServiceInfoSourceId = categoryInfo.Id
					};

					if (specialty.Id == 0)
					{
						specialtySourceRepository.Insert(specialty);
					}

					var optionElements = specialtiesBlocks[specIndex].FindElements(By.TagName("span"));
					foreach (var optionElement in optionElements)
					{
						optionsWithSpecialities.Add(optionElement.Text, specialty.Id);
					}
				}
			}
			catch
			{

			}

			var isDetailsPageOpen = false;
			while (!isDetailsPageOpen)
			{
				try
				{
					var checkAvailabilityButtonElement = driver.FindElement(By.XPath("//button//span//span[contains(text(),'Check availability')]"));
					checkAvailabilityButtonElement.Click();
					isDetailsPageOpen = true;
				}
				catch (Exception)
				{
					var bodyElement = driver.FindElement(By.TagName("body"));
					bodyElement.SendKeys(Keys.PageUp);
				}
			}

			var isStartQuestion = true;

			QuestionSource prevQuestion = null;

			while (true)
			{
				wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//div//div")));
				var headerElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//div//div"));
				string heading = headerElement.Text;

				string subHeading = null;
				try
				{
					var subHeaderElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//div//p"));
					subHeading = subHeaderElement.Text;
				}
				catch
				{
					subHeading = null;
				}

				string placeholder = null;
				AnswerType type = AnswerType.Custom;

				var formfields = driver.FindElements(By.XPath("//div[@data-test='request-flow-step--active']//ol[@class='tp-form-fields']//li[@class='tp-form-field__item']"));
				if (formfields.Count > 1)
				{
					type = AnswerType.Custom;
				}
				else
				{
					try
					{
						var inputElement = formfields[0].FindElement(By.TagName("input"));
						var typeName = inputElement.GetAttribute("type");
						placeholder = inputElement.GetAttribute("placeholder");
						if (typeName == "radio")
						{
							type = AnswerType.Select;
						}
						else if (typeName == "checkbox")
						{
							type = AnswerType.MultiSelect;
						}
						else if (typeName == "text" && placeholder == "First and last name")
						{
							type = AnswerType.FullName;
						}
						else if (placeholder == "Zip code")
						{
							type = AnswerType.ZipCode;
						}
						else if (typeName == "text")
						{
							type = AnswerType.Text;
						}
					}
					catch
					{
						try
						{
							var textEl = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//*[@data-test='request-flow-text-box']"));
							var typeName = textEl.GetAttribute("type");
							placeholder = textEl.GetAttribute("placeholder");
							if (typeName == "email")
							{
								type = AnswerType.Email;
							}
							else if(typeName == "textarea")
							{
								type = AnswerType.TextArea;
							}
							else if(typeName == "text")
							{
								type = AnswerType.Text;
							}
						}
						catch
						{
							type = AnswerType.Custom;
						}
					}
				}

				var options = new List<OptionSource>();

				if(type == AnswerType.Select || type == AnswerType.MultiSelect)
				{
					var spanElements = driver.FindElements(By.XPath("//div[@data-test='request-flow-step--active']//ol[@class='tp-form-fields']//span"));
					for(var optionIndex = 0; optionIndex < spanElements.Count(); optionIndex++)
					{
						var text = spanElements[optionIndex].Text;
						string optionPlaceholder = null;

						if (string.IsNullOrEmpty(text))
						{
							var inputElement = spanElements[optionIndex].FindElement(By.TagName("input"));
							optionPlaceholder = inputElement.GetAttribute("placeholder");
						}

						var option = new OptionSource()
						{
							Text = text,
							Placeholder = optionPlaceholder,
							Order = optionIndex
						};

						if (optionsWithSpecialities.ContainsKey(text))
						{
							option.SpecialtySourceId = optionsWithSpecialities[text];
						}

						options.Add(option);
					}
				}

				var question = questionRepository.Table.FirstOrDefault(q=>q.ServiceInfoSourceId == categoryInfo.Id && q.Heading == heading) ?? new QuestionSource()
				{
					ServiceInfoSourceId = categoryInfo.Id,
					Heading = heading,
					SubHeading = subHeading,
					IsStartQuestion = isStartQuestion,
					Placeholder = placeholder,
					Type = type
				};

				if(question.Id == 0)
				{
					questionRepository.Insert(question);
					if(prevQuestion!= null)
					{
						prevQuestion.NextQuestionSourceId = question.Id;
						questionRepository.Update(prevQuestion);
					}

					prevQuestion = question;

					if (options.Count > 0)
					{
						foreach (var option in options)
						{
							option.QuestionSourceId = question.Id;
							optionRepository.Insert(option);
						}
					}
				}

				try
				{
					var submitButtonElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//button//span[contains(text(),'Submit')]"));

					var closeButtonElement = driver.FindElement(By.XPath("//button[@aria-label='Close']"));
					closeButtonElement.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Cancel Request')]")));

					var cancelRequestButtonElement = driver.FindElement(By.XPath("//button[contains(text(),'Cancel Request')]"));
					cancelRequestButtonElement.Click();
					break;
				}
				catch
				{
					var submitButtonElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//button[@type='submit']"));
					submitButtonElement.Click();
					Task.Delay(1000).GetAwaiter().GetResult();
				}

				var newHeaderElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//div//div"));
				string newHeading = newHeaderElement.Text;
				if (newHeading == question.Heading)
				{
					question.IsRequired = true;
					questionRepository.Update(question);

					switch (question.Type)
					{
						case AnswerType.Custom:
							try
							{
								var nextDate = DateTime.UtcNow.AddDays(1);
								var dayPickerElement = driver.FindElement(By.XPath($"//div[@data-test='request-flow-step--active']//div[@class='DayPicker-Day'][contains(text(), '{nextDate.Day}')]"));
								dayPickerElement.Click();

							}
							catch
							{
								try
								{
									var hoursInputElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//input[@type='number']"));
									hoursInputElement.Clear();
									hoursInputElement.Click();
									hoursInputElement.SendKeys("1");
								}
								catch
								{

								}
							}
							
							break;
						case AnswerType.Email:
							var emailCodeElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//input"));
							emailCodeElement.Clear();
							emailCodeElement.Click();
							emailCodeElement.SendKeys($"john.smith{question.Id}@gmail.com");
							break;
						case AnswerType.ZipCode:
							var zipCodeElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//input"));
							zipCodeElement.Clear();
							zipCodeElement.Click();
							zipCodeElement.SendKeys(zipCode);
							break;
						case AnswerType.FullName:
							var fullName = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//input"));
							fullName.Clear();
							fullName.Click();
							fullName.SendKeys("John Smith");
							break;
						case AnswerType.MultiSelect:
						case AnswerType.Select:
							var spanElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//ol[@class='tp-form-fields']//span"));
							spanElement.Click();
							try
							{
								var inputEl = spanElement.FindElement(By.TagName("input"));
								inputEl.Clear();
								inputEl.Click();
								inputEl.SendKeys("John Smith");
							}
							catch
							{

							}
							break;
						case AnswerType.TextArea:
							var textareaCodeElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//textarea"));
							textareaCodeElement.Clear();
							textareaCodeElement.Click();
							textareaCodeElement.SendKeys($"Some information about project");
							break;
						case AnswerType.Text:
							var someInput = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//div[contains(@class, 'ph4')]//input"));
							someInput.Clear();
							someInput.Click();
							someInput.SendKeys("John Smith");
							break;
					}
				}

				isStartQuestion = false;
				try
				{
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-test='request-flow-step--active']//button//span")));
					var notNowElement = driver.FindElement(By.XPath("//div[@data-test='request-flow-step--active']//button//span[contains(text(),'Not now')]"));

					var closeButtonElement = driver.FindElement(By.XPath("//button[@aria-label='Close']"));
					closeButtonElement.Click();

					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Cancel Request')]")));

					var cancelRequestButtonElement = driver.FindElement(By.XPath("//button[contains(text(),'Cancel Request')]"));
					cancelRequestButtonElement.Click();
					break;
				}
				catch
				{

				}
			}
		}

		public static void ParseAddonsPerThumbtackCategory(ChromeDriver driver, FrontierProsObjectContext db, ServiceInfoSource categoryInfo)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			//Go to Services page
			driver.Navigate().GoToUrl(@"https://www.thumbtack.com/services");

			var button  = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'+ Add Service')]")));
			button.Click();

			var searchElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='What service do you provide?']")));
			searchElement.SendKeys(categoryInfo.Name);
			searchElement.Click();

			Task.Delay(2000).GetAwaiter().GetResult();

			var searchDropdownItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='SearchForm-dropdown-category ng-scope']//div[contains(text(),'{categoryInfo.Name}')]")));
			searchDropdownItem.Click();

			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-test='service-setting-bar__action-btn']")));

			driver.Navigate().GoToUrl(@"https://www.thumbtack.com/services");

			var serviceSection = driver.FindElement(By.XPath($"//div[contains(text(),'{categoryInfo.Name}')]"));
			serviceSection.Click();
			
			var hasPricesSection = driver.FindElements(By.XPath($"//p[contains(text(),'Prices')]")).Count() > 0;
			if (hasPricesSection)
			{
				var pricesSection = driver.FindElement(By.XPath($"//p[contains(text(),'Prices')]"));
				pricesSection.Click();

				try
				{
					var setupButton = driver.FindElement(By.XPath("//div[contains(text(),'Set up')]"));
					setupButton.Click();
				}
				catch
				{

				}

				var hasAddOnsSection = driver.FindElements(By.XPath("//p[contains(text(),'ADD-ONS')]")).Count() > 0;
				if (hasAddOnsSection)
				{
					var optionBlocks = driver.FindElements(By.XPath("//p[contains(text(),'ADD-ONS')]//following-sibling::div[@class='pricing-layout']/div"));
					foreach(var block in optionBlocks)
					{
						var labelElements = block.FindElements(By.TagName("label"));

						if (block.GetAttribute("class") == "pricing-layout__item")
						{
							var parentLabelText = string.Empty;

							for (var labelIndex = 0; labelIndex < labelElements.Count; labelIndex++)
							{
								var text = labelElements[labelIndex].Text;
								if (!string.IsNullOrEmpty(text))
								{
									parentLabelText = text;
									Console.WriteLine($"Parent:{parentLabelText}");
									break;
								}
							}

							var addon = new AddonSource()
							{
								ServiceInfoSourceId = categoryInfo.Id,
								Name = parentLabelText
							};
							db.Add(addon);
							db.SaveChanges();

						}
						else
						{
							var labelIndex = 0;
							var parentLabelText = string.Empty;

							for (; labelIndex < labelElements.Count; labelIndex++)
							{
								var text = labelElements[labelIndex].Text;
								if (!string.IsNullOrEmpty(text))
								{
									parentLabelText = text;
									labelIndex++;
									break;
								}
							}

							var addon = new AddonSource()
							{
								ServiceInfoSourceId = categoryInfo.Id,
								Name = parentLabelText
							};
							db.Add(addon);
							db.SaveChanges();

							Console.WriteLine($"Parent:{parentLabelText}");

							for (; labelIndex < labelElements.Count; labelIndex++)
							{
								var text = labelElements[labelIndex].Text;
								if (!string.IsNullOrEmpty(text))
								{
									var addonItem = new AddonItem()
									{
										Name = text,
										AddonId = addon.Id
									};
									db.Add(addonItem);
									db.SaveChanges();
									Console.WriteLine($"- {text}");
								}
							}
						}
					}
				}
			}
			

			driver.Navigate().GoToUrl(@"https://www.thumbtack.com/services");

			serviceSection = driver.FindElement(By.XPath($"//div[contains(text(),'{categoryInfo.Name}')]"));
			serviceSection.Click();
			try
			{
				var buttonToDeactivate = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[contains(text(),'Deactivate this service')]")));
				buttonToDeactivate.Click();
			}
			catch
			{
				var bodyElement = driver.FindElement(By.TagName("body"));
				bodyElement.SendKeys(Keys.PageDown);

				var buttonToDeactivate = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//button[contains(text(),'Deactivate this service')]")));
				buttonToDeactivate.Click();
			}

			Task.Delay(2000).GetAwaiter().GetResult();

			var removeBtn = driver.FindElement(By.XPath($"//span[contains(text(),'Remove')]"));
			removeBtn.Click();

		}
		#endregion

	}
}
