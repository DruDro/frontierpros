<template lang="pug">
	v-layout.profile.tabs-section(align-stretch fluid py-0)
		v-flex.tabs-main
			v-layout.page-header(row :wrap="$vuetify.breakpoint.lgAndDown" align-center justify-space-between)
				v-flex.tab-title(grow mr-4 ) {{childTitle}}
				v-flex.tabs(:shrink="$vuetify.breakpoint.lgAndUp" mr-4  :hidden="$vuetify.breakpoint.width < 1600")
					v-layout(row)
						v-flex(v-for="(tab,index) in tabs" :key="index" :xs12="$vuetify.breakpoint.smAndDown" v-if="tab.hidden !== true")
							router-link.btn.custom.full-width( :to="tab.to" ) {{ tab.title }}
				v-flex(shrink)
					v-menu(offset-y left)
						template( v-slot:activator="{on}")
							v-btn(flat icon color="primary" v-on="on")
								v-icon() fas fa-ellipsis-h
						v-list
							v-list-tile()
								v-list-tile-title Add Job
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
            providerQuestions: [],
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
                    to: `/provider/work/requests/`,
                    title: "Requests"
                },
                {
                    to: `/provider/work/jobs/`,
                    title: "Jobs"
                }
                // { to: `/services/${this.serviceId}/service-inventory`, title: "Inventory" },
                // { to: `/provider/services/${this.serviceId}/service-faq`, title: "FAQ" },
            ];
        }
    },
    methods: {
        passTitle(title) {
            this.childTitle = title;
        },
    },
    mounted() {
    }
};
</script>
<style lang="scss">
.tabs-main {
    width: 100%!important; //removed team sidebar for MVP
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
