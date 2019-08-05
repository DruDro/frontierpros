<template lang="pug">
	v-layout.profile.tabs-section(align-stretch fluid py-0 v-resize="onResize")
		v-flex.tabs-main
			v-layout.page-header(row :wrap="$vuetify.breakpoint.lgAndDown" align-center justify-space-between)
				v-flex(row nowrap d-flex justify-start align-center grow :class="{'mr-4 mb-5':$vuetify.breakpoint.lgAndUp,'mb-3 xs12':$vuetify.breakpoint.mdAndDown}" )
					v-flex.back-btn(mr-3 shrink style="flex:0 1 auto!important")
						v-btn(color="primary" icon to="/customer/services/")
							i.icon.fas.fa-chevron-left
					v-flex.align-left(grow)
						.tab-title {{ serviceName }}
						.tab-subtitle {{ serviceCategory }}
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
			transition(name="fade" mode="out-in")
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
import tabStyles from "../../../components/tabsView";
import Team from "./Team";
import $ from "jquery";
export default {
    components: {
        "service-team": Team
    },
    data() {
        return {
			serviceId: this.$route.params.id,
			serviceName: 'Service Name',// 'services/:ID' API endpoint needed
			serviceCategory: 'Service Category',// 'services/:ID' API endpoint needed
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
                { to: `/customer/services/${this.serviceId}/service-info`, title: "Info" },
                // { to: `/services/${this.serviceId}/service-inventory`, title: "Inventory" },
                { to: `/customer/services/${this.serviceId}/service-price`, title: "Price" },
				{ to: `/customer/services/${this.serviceId}/service-faq`, title: "FAQ" },
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
			this.detectRouteTab()
        }
    },
    watch: {
        $route() {
            this.detectRouteTab();
        }
    },
    mounted() {
    }
};
</script>
<style lang="scss">
.tabs-main{
	width:100%;//removed team sidebar for MVP
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
</style>
