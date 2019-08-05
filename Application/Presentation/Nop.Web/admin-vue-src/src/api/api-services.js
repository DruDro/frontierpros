import { UsersService } from "./services/users";
import { SourcesService } from "./services/sources";
import { ServicesService } from "./services/services";
import { QuestionnairesService } from "./services/questionnaires";
import { ServiceCategoriesService } from "./services/serivce-categories";

export class APIServices {
	static users = new UsersService();
	static sources = new SourcesService();
	static services = new ServicesService();
	static questionnaires = new QuestionnairesService();
	static serviceCategories = new ServiceCategoriesService();
}