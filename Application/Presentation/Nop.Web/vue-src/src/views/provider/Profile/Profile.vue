<template lang="pug">
	v-layout.profile.tabs-section(align-stretch fluid py-0 v-resize="onResize")
		v-flex.tabs-main
			v-layout.page-header(row :wrap="$vuetify.breakpoint.lgAndDown" align-center justify-space-between)
				v-flex.tab-title(grow :class="{'mr-4 mb-5':$vuetify.breakpoint.lgAndUp,'mb-3 xs12':$vuetify.breakpoint.mdAndDown}" ) {{ childTitle }}
				v-flex.tabs(:shrink="$vuetify.breakpoint.lgAndUp" mb-5  :hidden="$vuetify.breakpoint.width < 1600")
					v-layout(row)
						v-flex(v-for="(tab,index) in tabs" :key="index" :xs12="$vuetify.breakpoint.smAndDown" v-if="tab.hidden !== true")
							router-link.btn.custom.full-width( :to="tab.to" ) {{ tab.title }}
			card.bg.profile-strength
				h2.headline.font-weight-bold.pb-2 Profile Strength
					span.profile-strength-value.primary--text(:class="{'ml-3 d-inline-block':$vuetify.breakpoint.smAndUp,'d-block':$vuetify.breakpoint.xs}") Satisfactory
				.profile-strength-progress
					.step.completed
						.step-title Start
					.step.completed
						.step-title Upcoming
					.step.current
						.step-title Satisfactory
					.step
						.step-title Outstanding
			v-flex.tab-pager.pb-4.justify-space-between(d-flex :hidden="$vuetify.breakpoint.width >= 1024")
				v-flex( style="flex-grow: 0 !important")
					router-link.prev-link(v-if="previousTab" :to="previousTab.to" )
						span Previous Page
				v-flex( style="flex-grow: 0 !important" ml-5)
					router-link.next-link(v-if="nextTab" :to="nextTab.to" )
						span Next Page
			router-view(@passTitle="passTitle" @business-summary-profile-change="onBusinessSummaryProfileChanged")
			v-layout.tabs-footer(row wrap justify-space-between align-center mt-5 v-resize="detectRouteTab")
				v-flex.tab-pager(d-flex :class="{'pb-4 justify-space-between': $vuetify.breakpoint.xs, 'pr-4 shrink': $vuetify.breakpoint.smAndUp}")
					v-flex( style="flex-grow: 0 !important")
						router-link.prev-link(v-if="previousTab" :to="previousTab.to" )
							span Previous Page
					v-flex( style="flex-grow: 0 !important" ml-5)
						router-link.next-link(v-if="nextTab" :to="nextTab.to" )
							span Next Page
				v-flex(xs12 sm3 md2 style="position:relative" v-if="isOnBusinessSummaryRoute()")
					button.btn.primary.custom.large.full-width.text-capitalize(@click="saveProfile") save
					#chaat.chat(:hidden="$vuetify.breakpoint.width >= 1024")
						v-badge(color="white" )
							v-avatar.raised(size="40" color="primary" v-ripple)
								svg-icon(name="talk" size="20px" fill="#fff")
							span(slot="badge") 1
		general-info(:hidden="$vuetify.breakpoint.width < 1024")
</template>
<script>
import $ from "jquery";
import _ from "lodash";

import tabStyles from "../../../components/tabsView";
import GeneralInfo from "./GeneralInfo";

import { APIServices } from "../../../api/api-services";

export default {
	components: {
		"general-info": GeneralInfo
	},
	data() {
		return {
			previousTab: null,
			nextTab: null,
			childTitle: "",
			businessSummaryProfile: {}
		};
	},
	computed: {
		tabs() {
			return [
				{
					to: "/provider/profile/general-info",
					title: "General Info",
					hidden: this.$vuetify.breakpoint.width >= 1024
				},
				{ to: "/provider/profile/business-summary", title: "Business Summary" },
				{
					to: "/provider/profile/professional-license",
					title: "Professional License"
				},
				{ to: "/provider/profile/reviews", title: "Reviews" },
				{ to: "/provider/profile/photo-video", title: "Photo & Video" }
			];
		}
	},
	methods: {
		isOnBusinessSummaryRoute() {
			return this.$route.meta.title === "Business Summary";
		},
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
			if (
				window.innerWidth >= 1024 &&
				this.$route.matched[1].path.includes("general-info")
			) {
				this.$router.push(this.tabs[1].to);
			}
		},
		onBusinessSummaryProfileChanged(businessSummaryProfile) {
			this.businessSummaryProfile = businessSummaryProfile;
		},
		saveProfile() {
			if (!_.isEmpty(this.businessSummaryProfile)) {
				APIServices
					.providers
					.setBusinessInfo(this.businessSummaryProfile)
					.then(res => {
						if (res.data.success) {
							this.$store.commit("SET_PROFILE", this.businessSummaryProfile);
						}
					});
			}
		}
	},
	watch: {
		$route() {
			this.detectRouteTab();
		}
	},
	mounted() {
		 this.$store.dispatch("GET_PROFILE", "provider").then(profile => {
			this.profile = profile;
		});
	}
};
</script>

<style lang="scss">
.profile-strength {
	padding-bottom: 20px;
	margin-bottom: 60px;
	@include b(1599) {
		margin-bottom: 30px;
	}
	&-progress {
		display: flex;
		flex-flow: row nowrap;
		justify-content: stretch;
		overflow: hidden;
		padding: 0 8px;
		.step {
			position: relative;
			flex: 0 0 25%;
			text-align: center;
			&:before,
			&:after {
				display: block;
				content: "";
				position: absolute;
				width: 100%;
				top: 15px;
				left: -50%;
				height: 6px;
				background: #d2d9ee;
			}
			&.completed {
				&:before,
				&:after {
					background: #567be1;
				}
				.step-title:before {
					background: #7094f7;
				}
			}
			&.current {
				&:before,
				&:after {
					background: #18c3c8;
				}
				.step-title {
					color: #1c1c1c;
					@include b(tablet) {
						opacity: 1;
					}
					&:before {
						background: #fff;
						box-shadow: 0 0 0 8px #18c3c8;
					}
				}
			}
			&-title {
				padding: 45px 0 0;
				position: relative;
				color: rgba(#1c1c1c, 0.4);
				@include b(tablet) {
					font-size: 0;
					line-height: 0;
				}
				&:before {
					content: "";
					display: block;
					position: absolute;
					width: 16px;
					height: 16px;
					background: #87898d;
					left: 50%;
					top: 10px;
					transform: translateX(-50%);
					border-radius: 50%;
					z-index: 1;
				}
			}
			&:first-child {
				text-align: left;
				&:before,
				&:after {
					left: 8px;
				}
				.step-title:before {
					left: 0;
					transform: none;
				}
			}
			&:nth-child(2) {
				&:before,
				&:after {
					width: 150%;
					left: calc(-100% + 8px);
				}
			}
			&:last-child {
				text-align: right;
				&:after {
					left: auto;
					right: 0;
				}
				.step-title:before {
					left: auto;
					right: 0;
					transform: none;
				}
			}
		}
	}
}
.profile__details {
	.company {
		margin: 20px 0 15px;
	}
	.setting {
		display: flex;
		flex-flow: row nowrap;
		align-items: center;
		justify-content: space-between;
		& + .setting {
			margin-top: 15px;
		}
		& > label {
			font-size: 18px;
			font-weight: bold;
			color: #1c1c1c !important;
		}
	}
	.people {
		display: flex;
		flex-flow: row nowrap;
		justify-content: space-between;
		align-items: center;
		margin: 20px 0;
		.faces {
			display: flex;
			flex-flow: row-reverse nowrap;
			justify-content: flex-end;
			.v-avatar {
				box-shadow: 0 0 0 2px #fff;
				&:first-child ~ .v-avatar {
					margin-right: -21px;
				}
			}
		}
		.more {
			font-weight: bold;
		}
	}
	.profile__social {
		display: flex;
		align-items: center;
		justify-content: space-between;
		.net {
			color: #8d8d8d;
			font-size: 18px;
			&:hover {
				color: #7094f7;
			}
		}
	}
}
</style>
