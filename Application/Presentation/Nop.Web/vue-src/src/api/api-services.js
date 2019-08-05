import { UsersService } from "./services/users";
import { ServicesService } from "./services/services";
import { LocationsService } from "./services/locations";
import { ProvidersService } from "./services/providers";
import { CustomersService } from "./services/customers";
import { TimeZonesService } from "./services/time-zones";
import { ServiceItemsService } from "./services/service-items";
import { CoverageAreasService } from "./services/coverage-areas";
import { ConfirmationsService } from "./services/confirmations";
import { QuestionnairesService } from "./services/questionnaires";
import { ProviderReviewsService } from "./services/provider-reviews";
import { ProviderLicencesService } from "./services/provider-licenses";
import { ServiceCategoriesService } from "./services/service-categories";

export class APIServices {
    static users = new UsersService();
    static services = new ServicesService();
    static locations = new LocationsService();
    static providers = new ProvidersService();
    static customers = new CustomersService();
    static timeZones = new TimeZonesService();
    static serviceItems = new ServiceItemsService();
    static coverageAreas = new CoverageAreasService();
    static confirmations = new ConfirmationsService();
    static questionnaires = new QuestionnairesService();
    static providerReviews = new ProviderReviewsService();
    static providerLicences = new ProviderLicencesService();
    static serviceCategories = new ServiceCategoriesService();
}