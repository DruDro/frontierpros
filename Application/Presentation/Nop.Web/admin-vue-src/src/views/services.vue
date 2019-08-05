<template lang="pug">
v-container(fluid)
	v-card
		v-card-title Services
			v-spacer
			v-text-field(v-model="search" append-icon="search" placeholder="Search Service")
			v-spacer
			v-autocomplete(:loading="!categories.length" clearable :items="categories" v-model="filterServicesByCategory" item-value="Id" item-text="Name"  placeholder="Filter by Category")
			v-spacer
			v-dialog(persistent width="100%" :max-width="960" v-model="addQuestionnaireDialog")
				template(v-slot:activator="{on}")
					v-btn.btn.custom.primary(v-on="on") Add Service
				v-card
					v-toolbar
						v-btn(icon @click="closeQuestionnaireDialog")
							v-icon close
						v-toolbar-title Add Service
					v-card-text
						v-form(v-model="valid" lazy-validation ref="addCategoryForm" @submit.prevent)
							v-autocomplete(multiple :loading="!categories.length"  v-model="category" item-text="Name"  item-value="Id" :return-object="true"  :items="categories" label="Category Name" placeholder="Enter Category Name, e.g.: House Cleaning" :rules="NameRules" required )
								template(v-slot:selection="{item,index}")
									span(v-if="index === 0 ") {{item.Name}}
									span.gray--text.caption(v-if="index === 1") &nbsp;(+{{category.length - 1}} others)
							v-combobox( :loading="servicesLoading"  v-model="service" item-text="Name"  item-value="Id" :return-object="true"  :items="sourceServices" label="Service Name" type="text" placeholder="Enter Category Name, e.g.: House Cleaning" :rules="NameRules" required )
					v-card.elevation-5.mt-3
						v-card-title Questionnaire
						v-card-text
							.service(v-if="questionnaireOpen && questionnaire")
								v-expansion-panel.elevation-0( :v-model="false")
									draggable(v-model="questionnaire" handle=".handle" :move="onChangeQuestionnaireOrder")
										transition-group
											v-expansion-panel-content( v-for="question in questionnaire" :key="question.Id")
												template(slot="header")
													div
														v-icon.handle drag_indicator
														| &nbsp;{{question.Heading || "New Question"}}
												v-card
													v-form.pa-3
														v-card-actions
															v-spacer
															v-btn(color="red" dark @click="deleteQuestion(question)") Delete question
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-checkbox( v-model="question.IsRequired" label="Required")
																v-text-field(v-model="question.Heading" label="Heading" :placeholder="question.Placeholder")
																v-text-field(v-model="question.SubHeading" label="Sub-heading")
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-layout(justify-start)
																	v-flex.mr-4(shrink)
																		v-checkbox(v-model="question.IsProviderQuestion" label="Provider question")
																	v-flex(shrink v-if="question.IsProviderQuestion")
																		v-checkbox(v-model="question.IsPaidQuestion" label="Paid")
																v-text-field(v-if="question.IsProviderQuestion" label="Provider Heading" v-model="question.ProviderHeading")
																v-text-field(v-if="question.IsProviderQuestion" label="Provider Sub-heading" v-model="question.ProviderSubHeading")
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-select(v-model="question.Type" :items="questionTypes" label="Question input type" )
																template(v-if="question.Type == 'Select' || question.Type == 'MultiSelect'")
																	v-subheader Options
																	draggable(v-model="question.Options")
																		v-card(style="border:1px solid #dadada" flat v-for="option in question.Options" :key="option.Id")
																			v-card-text
																				v-layout(row align-center)
																					v-flex(shrink)
																						v-icon.handle drag_indicator
																					v-flex
																						v-layout(row wrap)
																							v-flex
																								v-text-field(label="Customer Text"  v-model="option.Text")
																							v-flex
																								v-text-field(label="Provider Text"  v-model="option.ProviderText")
																							v-flex(xs12)
																								v-select(label="Next Question" v-model="option.NextQuestionId" clearable item-value="Id" item-text="Heading" :items="questionnaire.filter(q => q.Id !== question.Id)" )
																					v-flex(shrink)
																						v-btn(icon @click="deleteOption(question,option)")
																							v-icon close
																	.pt-3.pb-4
																		v-btn.custom.transparent.btn(@click="addOption(question)")
																			v-icon add
																			span Add Option
																v-text-field(v-model="question.Placeholder" label="Answer Placeholder")
																v-select(v-if="question.Type !== 'Select'" v-model="question.NextQuestionId" :items="questionnaire.filter(q => q.Id !== question.Id)" item-text="Heading" item-value="Id" label="Next Question" clearable)
																v-checkbox(hide-details v-model="question.IsStartQuestion" label="Start Question")
								v-card-actions
									v-btn.custom.transparent.btn( @click="addQuestion")
										v-icon add
										span Add Question
								v-card-actions.py-4
									v-spacer
									v-btn.btn.custom.transparent(@click="closeQuestionnaireDialog") Cancel
									v-btn.btn.custom.primary.ml-4(@click="createService") Save Service
							v-progress-linear(:indeterminate="true" v-else)
		v-data-table(:loading="filterServicesByCategoryItems.length ? false:true" :search="search" :items="filterServicesByCategoryItems" :headers="tableHeaders")
			template(v-slot:items="props")
				td.text-center {{props.item.Id}}
				td() {{props.item.Name}}
				td
					span(v-for="(c,index) in props.item.ServiceCategories" :key="index")
						span(v-if="index > 0")
							|,
							| 
						| {{c.Name}}
				td.text-center {{ props.item.Published ? 'Yes':'No' }}
				td.layout.justify-center
					v-flex(shrink)
						v-btn(color="blue" dark icon @click="showEditQuestionnaireDialog(props.item)")
							v-icon(color="white") edit
					v-flex(shrink)
						v-btn(color="red" dark icon @click="deleteService(props.item)")
							v-icon(color="white") delete
		v-dialog(persistent width="100%" :max-width="960"  v-model="editQuestionnaireDialog")
			v-card
				v-toolbar
					v-btn(icon @click="closeQuestionnaireDialog")
						v-icon close
					v-toolbar-title Edit Service
				v-card-text
					v-form(v-model="valid" lazy-validation ref="addCategoryForm" @submit.prevent)
						v-autocomplete(multiple :loading="categories.length ? false : true"  v-model="category" item-text="Name"  item-value="Id" :return-object="true"  :items="categories" label="Category Name" placeholder="Enter Category Name, e.g.: House Cleaning" :rules="NameRules" required )
							template(v-slot:selection="{item,index}")
								span(v-if="index === 0 ") {{item.Name}}
								span.gray--text.caption(v-if="index === 1") &nbsp;(+{{category.length - 1}} others)
						v-text-field(v-model="editService.Name" @input.native="editService.Name=$event.srcElement.value" label="New Service Name")
						v-card-actions
							v-spacer
							v-btn.btn.custom.transparent(@click="closeQuestionnaireDialog") Cancel
							v-btn.ml-3.btn.custom.primary(@click="updateService") Save Changes
				v-card.elevation-5.mt-3
					v-card-title Questionnaire
					v-card-text
						.service(v-if="questionnaireOpen && questionnaire")
							v-expansion-panel.elevation-0( :v-model="false")
									draggable(v-model="questionnaire" handle=".handle" :move="onChangeQuestionnaireOrder")
										transition-group
											v-expansion-panel-content( v-for="question in questionnaire" :key="question.Id")
												template(slot="header")
													div
														v-icon.handle drag_indicator
														| &nbsp;{{question.Heading || "New Question"}}
												v-card
													v-form.pa-3
														v-card-actions
															v-spacer
															v-btn(color="red" dark @click="deleteQuestion(question)") Delete question
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-checkbox( v-model="question.IsRequired" label="Required")
																v-text-field(v-model="question.Heading" label="Heading" :placeholder="question.Placeholder")
																v-text-field(v-model="question.SubHeading" label="Sub-heading")
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-layout(justify-start)
																	v-flex.mr-4(shrink)
																		v-checkbox(v-model="question.IsProviderQuestion" label="Provider question")
																	v-flex(shrink v-if="question.IsProviderQuestion")
																		v-checkbox(v-model="question.IsPaidQuestion" label="Paid")
																v-text-field(v-if="question.IsProviderQuestion" label="Provider Heading" v-model="question.ProviderHeading")
																v-text-field(v-if="question.IsProviderQuestion" label="Provider Sub-heading" v-model="question.ProviderSubHeading")
														v-card.my-3.elevation-15(raised)
															v-card-text
																v-select(v-model="question.Type" :items="questionTypes" label="Question input type" )
																template(v-if="question.Type == 'Select' || question.Type == 'MultiSelect'")
																	v-subheader Options
																	draggable(v-model="question.Options")
																		v-card(style="border:1px solid #dadada" flat v-for="option in question.Options" :key="option.Id")
																			v-card-text
																				v-layout(row align-center)
																					v-flex(shrink)
																						v-icon.handle drag_indicator
																					v-flex
																						v-layout(row wrap)
																							v-flex
																								v-text-field(label="Customer Text"  v-model="option.Text")
																							v-flex
																								v-text-field(label="Provider Text"  v-model="option.ProviderText")
																							v-flex(xs12)
																								v-select(label="Next Question" v-model="option.NextQuestionId" clearable item-value="Id" item-text="Heading" :items="questionnaire.filter(q => q.Id !== question.Id)" )
																					v-flex(shrink)
																						v-btn(icon @click="deleteOption(question,option)")
																							v-icon close
																	.pt-3.pb-4
																		v-btn.custom.transparent.btn(@click="addOption(question)")
																			v-icon add
																			span Add Option
																v-text-field(v-model="question.Placeholder" label="Answer Placeholder")
																v-select(v-if="question.Type !== 'Select'" v-model="question.NextQuestionId" :items="questionnaire.filter(q => q.Id !== question.Id)" item-text="Heading" item-value="Id" label="Next Question" clearable)
																v-checkbox(hide-details v-model="question.IsStartQuestion" label="Start Question")
							v-card-actions
								v-btn.custom.transparent.btn( @click="addQuestion")
									v-icon add
									span Add Question
							v-card-actions.py-4
								v-spacer
								v-btn.btn.custom.transparent(@click="closeQuestionnaireDialog") Cancel
								v-btn.btn.custom.primary(@click="saveQuestionnaire") Save Questionnaire
						v-progress-linear(:indeterminate="true" v-else)
</template>

<script>
import { capitalize } from "../variables";
import draggable from "vuedraggable";

import { APIServices } from '../api/api-services';

export default {
    components: {
        draggable
    },
    data() {
        return {
            search: "",
            filterServicesByCategory: null,
            filterServicesByCategoryItems: [],
            tableHeaders: [
                {
                    text: "ID",
                    value: "Id",
                    align: "center",
                    width: "100px"
                },
                {
                    text: "Service Name",
                    value: "Name",
                    align: "left"
                },
                {
                    text: "Service Categories",
                    value: "ServiceCategories",
                    align: "center",
                    align: "left"
                },
                {
                    text: "Published",
                    value: "Published",
                    align: "center"
                },
                {
                    text: "Actions",
                    value: "Name",
                    sortable: false,
                    width: "200px",
                    align: "center"
                }
            ],
            uniqueId: -1,
            addQuestionnaireDialog: false,
            editQuestionnaireDialog: false,
            questionnaireOpen: false,
            questionnaire: [],
            questionTypes: [
                "MultiSelect",
                "Select",
                "Email",
                "ZipCode",
                "FullName",
                "TextArea",
                "Custom",
                "Text",
                "Number",
                "DropDown",
                "Date",
                "Location"
            ],
            valid: false,
            categories: [],
            category: [],
            serviceExists: true,
            sourceServices: [],
            services: [],
            servicesLoading: true,
            service: {
                Id: null,
                Name: ""
            },
            editService: {
                Id: null,
                Name: ""
            },
            NameRules: [
                v => !!v || "Please enter the Category Name",
                v => !!v || "Category Name must be at least 3 letters"
            ]
        };
    },
    watch: {
        filterServicesByCategory: {
            handler: function() {
                this.filterServices();
            },
            deep: true
        },
        service: {
            handler: function(v) {
                if (this.addQuestionnaireDialog) {
                    console.log(v, this.service);
                    if (typeof v == "string") {
                        this.serviceExists = false;
                    }
                    if (this.serviceExists) {
                        console.log("service exists");
                        this.getSourceServiceQuestionnaire();
                    } else {
                        console.log("service does not exist");
                        this.createNewQuestionnaire();
                    }
                }
            },
            deep: true
        }
    },
    methods: {
        getCategories() {
            APIServices
                .serviceCategories
                .getCategroies()
                .then(res => {
                    console.log(res.data);
                    this.categories = res.data;
                });
        },
        getAllSourceServices() {
            this.servicesLoading = true;
            APIServices
                .sources
                .getAllSourceServices()
                .then(res => {
                    console.log(res.data);
                    this.sourceServices = res.data;
                    this.servicesLoading = false;
                });
        },
        getServices() {
            APIServices
                .services
                .getServices({ includeCategories: true })
                .then(res => {
                    console.log(res.data);
                    this.services = res.data;
                    this.filterServicesByCategoryItems = res.data;
                    this.servicesLoading = false;
                });
        },
        getSourceServiceQuestionnaire() {
            this.questionnaire = [];
            APIServices
                .sources
                .getSourceServiceQuestionnaire(this.service.Id)
                .then(res => {
                    this.questionnaire = res.data;
                    this.questionnaireOpen = true;
                });
        },
        filterServices() {
            console.log(this.filterServicesByCategory);
            this.filterServicesByCategoryItems = this.services.map(s => {
                return {
                    Id: s.Id,
                    Name: s.Name,
                    ServiceCategories: s.ServiceCategories,
                    ServiceCategoryIds: s.ServiceCategories.map(c => c.Id)
                };
            });
            if (this.filterServicesByCategory) {
                this.filterServicesByCategoryItems = this.filterServicesByCategoryItems.filter(
                    s =>
                        s.ServiceCategoryIds.includes(
                            this.filterServicesByCategory
                        )
                );
            } else {
                this.filterServicesByCategoryItems = this.services;
            }
        },
        createService() {
            if (this.$refs.addCategoryForm.validate()) {
                let serviceName;
                if (typeof this.service == "string") {
                    serviceName = this.service;
                } else {
                    serviceName = this.service.Name;
                }
                APIServices
                    .services
                    .createService({
                        Name: capitalize(serviceName),
                        ServiceCategoryIds: this.category.map(cat => cat.Id)
                    })
                    .then(res => {
                        if (res.data.success) {
                            let service = {
                                Id: res.data.id,
                                Name: capitalize(serviceName),
                                ServiceCategoryIds: this.category.map(
                                    cat => cat.Id
                                )
                            };

                            this.createQuestionnaire(service);
                        } else {
                            alert(res.data.message);
                        }
                    });
            }
        },
        createQuestionnaire(service) {
            console.log(this.questionnaire);
			for(let i = 0; i < this.questionnaire.length; i++){
				this.questionnaire[i].Order = i;
				for(let j = 0; j < this.questionnaire[i].Options.length; j++){
					this.questionnaire[i].Options[j].Order = j;
				}
			}
			let questionnaire = { Questions: this.questionnaire };
            APIServices
                .questionnaires
                .createQuestionnaire(service.Id, questionnaire)
                .then(res => {
                    if (res.data.success) {
                        this.closeQuestionnaireDialog();
                        this.getServices();
                    } else {
                        alert(res.data.message);
                    }
                });
        },
        generateId() {
            this.uniqueId--;
            return this.uniqueId;
        },
        addQuestion() {
            this.questionnaire.push({
                Heading: "",
                Id: this.generateId(),
                IsProviderQuestion: false,
                IsRequired: false,
                IsStartQuestion: false,
                NextQuestionId: null,
                Placeholder: null,
                ProviderHeading: "",
                ProviderSubHeading: null,
                SubHeading: null,
                Type: "MultiSelect",
				Options: [],
				Order:0
            });
        },
        addOption(q) {
            q.Options.push({
                Id: this.generateId(),
                ProviderText: "",
                Text: "",
                Order: 0,
                NextQuestionId: null
            });
        },
        deleteQuestion(q) {
            this.questionnaire.splice(this.questionnaire.indexOf(q), 1);
        },
        deleteOption(q, o) {
            let questionIndex = this.questionnaire.indexOf(q);
            this.questionnaire[questionIndex].Options.splice(
                this.questionnaire[questionIndex].Options.indexOf(o),
                1
            );
        },
        createNewQuestionnaire() {
            this.addQuestion();
            this.questionnaireOpen = true;
        },
        addQuestionnaire() {
            this.createService();
        },
        clearAll() {
            (this.questionsOrder = []), (this.uniqueId = -1);
            this.addQuestionnaireDialog = false;
            this.editQuestionnaireDialog = false;
            this.questionnaireOpen = false;
            this.valid = false;
            this.category = [];
            this.service = {
                Id: null,
                Name: ""
            };
            this.serviceExists = true;
            this.questionnaire = [];
        },
        closeQuestionnaireDialog() {
            this.clearAll();
        },

        // edit functionality
        showEditQuestionnaireDialog(service) {
            this.editQuestionnaireDialog = true;
            this.editService = service;
            let selectedServiceCategoryIds = service.ServiceCategories.map(
                c => c.Id
            );
            this.category = this.categories.filter(el => selectedServiceCategoryIds.indexOf(el.Id) !== -1);
            this.getServiceQuestionnaire();
        },
        deleteService(service) {
            if (
                confirm(
                    `Do you really want to delete the ${service.Name} service?`
                )
            ) {
                APIServices
                    .services
                    .deleteService(service.Id)
                    .then(res => {
                        this.getServices();
                        alert("Service successfully deleted!");
                    });
            }
        },
        updateService() {
            console.log(this.category);
            let serviceParams = {
                Id: this.editService.Id,
                Name: this.editService.Name,
                ServiceCategoryIds: this.category.map(c => c.Id)
            };
            APIServices
                .services
                .updateService(serviceParams)
                .then(res =>
                    res.data.success
                        ? alert("Service name updated!")
                        : alert(res.data.message)
                )
                .catch(err => console.log(err));
        },
        getServiceQuestionnaire() {
            APIServices
                .questionnaires
                .getServiceQuestionnaire(this.editService.Id)
                .then(res => {
                    if (res.data) {
                        this.questionnaire = res.data;
                    } else {
                        this.createNewQuestionnaire();
                    }
                    console.log(res.data);
                    this.questionnaireOpen = true;
                });
        },
        saveQuestionnaire(service) {			
			for(let i = 0; i < this.questionnaire.length; i++){
				this.questionnaire[i].Order = i;
				for(let j = 0; j < this.questionnaire[i].Options.length; j++){
					this.questionnaire[i].Options[j].Order = j;
				}
			}
			let questionnaire = { Questions: this.questionnaire };
            APIServices
                .questionnaires
                .updateQuestionnaire(this.editService.Id, questionnaire)
                .then(res => {
                    this.closeQuestionnaireDialog();
                    this.getServices();
                });
		},
		getNextQuestionId(question){
			let result;
			if(question.Type == 'Select'){
				if(question.Options.length > 0){
					let isSameNextQuestionId = true;
					let nextQuestionId = question.Options[0].NextQuestionId;
					for(let i = 0; i < question.Options.length; i++){
						if(nextQuestionId !== question.Options[i].NextQuestionId){
							isSameNextQuestionId = false;
							break;
						}
					}	
					if(isSameNextQuestionId){
						result = nextQuestionId;
					}
				}
			}else{
				result = question.NextQuestionId;
			}

			return result;
		},
		setNextQuestionId(question, nextQuestionId){
			if(question.Type == 'Select'){
				for(let i = 0; i < question.Options.length; i++){
					question.Options[i].NextQuestionId = nextQuestionId;
				}
				question.NextQuestionId = null;
			}else{
				question.NextQuestionId = nextQuestionId;
			}
		},
		onChangeQuestionnaireOrder:_.debounce(function(data){
			console.log(data)
			let questionIndex = data.draggedContext.futureIndex;
			let prevQuestionIndex = questionIndex - 1;
			let nextQuestionIndex = questionIndex + 1;

			let hasPrevQuestion = prevQuestionIndex >= 0;
			let hasNextQuestion = nextQuestionIndex < this.questionnaire.length;
            
            let current_NextQuestionId = this.getNextQuestionId(this.questionnaire[questionIndex]);
            if(!current_NextQuestionId){
                if(hasPrevQuestion && hasNextQuestion){
                    //center
                    let prev_NextQuestionId = this.getNextQuestionId(this.questionnaire[prevQuestionIndex]);
                    if(prev_NextQuestionId == this.questionnaire[nextQuestionIndex].Id){
                        this.setNextQuestionId(this.questionnaire[prevQuestionIndex],this.questionnaire[questionIndex].Id);
                        this.setNextQuestionId(this.questionnaire[questionIndex],this.questionnaire[nextQuestionIndex].Id);
                    }

                }else if(hasPrevQuestion && !hasNextQuestion){
                    //bottom
                    let prev_NextQuestionId = this.getNextQuestionId(this.questionnaire[prevQuestionIndex]);
                    if(!prev_NextQuestionId){
                        this.setNextQuestionId(this.questionnaire[prevQuestionIndex], this.questionnaire[questionIndex].Id);
                    }
                }else if(!hasPrevQuestion && hasNextQuestion){
                    //top
                    this.setNextQuestionId(this.questionnaire[questionIndex], this.questionnaire[nextQuestionIndex].Id);
                }
            }
			return true
		}, 500)
    },
    mounted() {
        this.getServices();
        this.getCategories();
        this.getAllSourceServices();
    }
};
</script>

<style lang="scss" scoped>
</style>