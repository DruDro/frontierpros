<template lang="pug">
	v-layout.profile.tabs-section(align-stretch fluid py-0 v-resize="onResize")
		v-flex.tabs-main
			v-layout.page-header(row :wrap="$vuetify.breakpoint.lgAndDown" align-center justify-space-between)
				v-flex(row nowrap d-flex justify-start align-center grow :class="{'mr-4 mb-5':$vuetify.breakpoint.lgAndUp,'mb-3 xs12':$vuetify.breakpoint.mdAndDown}" )
					v-flex.back-btn(mr-3 shrink style="flex:0 1 auto!important")
						v-btn(color="primary" icon to="/provider/services/")
							i.icon.fas.fa-chevron-left
					v-flex.align-left(grow)
						.tab-title Request Title Lorem Ipsum
						.tab-subtitle {{ requestId }}
				v-flex.tabs(:shrink="$vuetify.breakpoint.lgAndUp" mb-5  :hidden="$vuetify.breakpoint.width < 1600")
					v-layout(row)
						v-flex(v-for="(tab,index) in tabs" :key="index" :xs12="$vuetify.breakpoint.smAndDown" v-if="tab.hidden !== true")
							router-link.btn.custom.full-width( :to="tab.to" ) {{ tab.title }}
			v-flex.tab-pager.pb-4.justify-space-between(d-flex :hidden="$vuetify.breakpoint.width >= 1600")
				v-flex( style="flex-grow: 0 !important")
					router-link.prev-link(v-if="previousTab" :to="previousTab.to" )
						span Previous Page
				v-flex( style="flex-grow: 0 !important" ml-5)
					router-link.next-link(v-if="nextTab" :to="nextTab.to" )
						span Next Page
			router-view(@passTitle="passTitle")
			v-layout.tabs-footer(row wrap justify-space-between align-center mt-5 )
				v-flex.tab-pager(d-flex :class="{'pb-4 justify-space-between': $vuetify.breakpoint.xs, 'pr-4 shrink': $vuetify.breakpoint.smAndUp}")
					v-flex( style="flex-grow: 0 !important")
						router-link.prev-link(v-if="previousTab" :to="previousTab.to" )
							span Previous Page
					v-flex( style="flex-grow: 0 !important" ml-5)
						router-link.next-link(v-if="nextTab" :to="nextTab.to" )
							span Next Page
				v-flex(xs12 sm3 md2 style="position:relative")
					button.btn.primary.custom.large.full-width.text-capitalize() save
					#chaat.chat(:hidden="$vuetify.breakpoint.width >= 1600")
						v-badge(color="white" )
							v-avatar.raised(size="40" color="primary" v-ripple)
								svg-icon(name="talk" size="20px" fill="#fff" )
							span(slot="badge") 1
		//- service-team(:hidden="$vuetify.breakpoint.width < 1600")
</template>
<script>
import tabStyles from "@/components/tabsView";
import $ from "jquery";
export default {
    data() {
        return {
            request: {},
            requestId: this.$route.params.id,
            previousTab: null,
            nextTab: null,
            childTitle: ""
        };
    },
    computed: {
        tabs() {
            return [
                // {
                //     to: "/services/:id/service-team",
                //     title: "Team",
                //     hidden: this.$vuetify.breakpoint.width >= 1024
                // },
                {
                    to: `/provider/work/requests/${this.requestId}/info`,
                    title: "Info"
                },
                // { to: `/services/${this.serviceId}/service-inventory`, title: "Inventory" },
                {
                    to: `/provider/work/requests/${this.requestId}/issue`,
                    title: "Issue"
                },
                // { to: `/services/${this.serviceId}/service-inventory`, title: "Inventory" },
                {
                    to: `/provider/work/requests/${this.requestId}/price`,
                    title: "Price"
                }
                // { to: `/provider/services/${this.serviceId}/service-faq`, title: "FAQ" },
            ];
        }
    },
    methods: {
        passTitle(title) {
            this.childTitle = title;
        },
        detectRouteTab() {
            const handleTab = index => {
                if (index < this.tabs.length) {
                    this.nextTab = this.tabs[index + 1]
                        ? this.tabs[index + 1].hidden !== true
                            ? this.tabs[index + 1]
                            : null
                        : null;
                    if (index > 0) {
                        this.previousTab = this.tabs[index - 1]
                            ? this.tabs[index - 1].hidden !== true
                                ? this.tabs[index - 1]
                                : null
                            : null;
                    } else {
                        this.previousTab = null;
                    }
                } else {
                    this.nextTab = null;
                }
            };
            const routeTab = () => {
                let curTab = 0;
                this.tabs.forEach((tab, index) => {
                    if (tab.to === this.$route.path) {
                        curTab = index;
                    }
                });
                return curTab;
            };
            handleTab(routeTab());
        },
        onResize() {
            // if (
            //     window.innerWidth >= 1024 &&
            //     this.$route.matched[1].path.includes("service-team")
            // ) {
            //     this.$router.push(this.tabs[1].to);
            // }
            this.detectRouteTab();
        },
        getServiceItem() {
            this.$store
                .dispatch("GET_SERVICE_ITEM", {
                    id: this.serviceId,
                    role: "provider"
                })
                .then(serviceItem => {
                    this.serviceItem = serviceItem;
                    this.getProviderQuestions(this.serviceItem.ServiceInfoId, this.serviceItem.Settings);
                });
        },
        getProviderQuestions(serviceInfoId, settings) {
            this.$store
                .dispatch("GET_PROVIDER_QUESTIONS", {serviceInfoId, settings})
                .then(providerQuestions => {
					this.providerQuestions = providerQuestions;
                });
        },
        saveServiceItem() {
			let settings = [];
			this.providerQuestions.forEach(q => {
				for(let i = 0; i < q.Options.length; i++){
					settings.push({
							OptionId: q.Options[i].Id,
							Price: q.Options[i].Price,
							IsActive: q.Options[i].IsActive,
							ServiceItemId: this.serviceId
					});
				}
			});
			this.serviceItem.Settings = settings;
            this.$store.dispatch("UPDATE_SERVICE_ITEM", this.serviceItem);
        },
        getServices() {
            this.$store.dispatch("GET_SERVICES");
        }
    },
    watch: {
        $route() {
            this.detectRouteTab();
        }
    },
    mounted() {
        this.getServiceItem();
        this.getServices();
    }
};
</script>
<style lang="scss">
.tabs-main {
    width: 100%; //removed team sidebar for MVP
    // @include b(1599){
    // 	width:100%
    // }
}
.chat {
    @include b(1599) {
        left: auto;
        transform: none;
        z-index: 2;
        right: 0;
        bottom: -30px;
        .v-badge__badge {
            height: 16px;
            width: 16px;
            font-size: 10px;
            top: 0;
            right: 0;
        }
    }
}

.custom-label,
.v-text-field .v-label {
    font-size: 18px;
    color: rgb(28, 28, 28) !important;
    font-weight: bold;
    transform: translateY(-35px);
}
.v-text-field .v-label--active {
    transform: translateY(-35px);
}
</style>
