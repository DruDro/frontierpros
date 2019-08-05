<template lang="pug">
v-toolbar#header.header(app color="white" :height="$vuetify.breakpoint.width >= 1600 ? 80:50")
	gradient
	v-flex( shrink mr-5 :class="{'hidden':$vuetify.breakpoint.width < 1600}")
		v-btn(icon :href="landingUrl")
			svg-icon.gradient(name="info" width="40px" height="40px")
	v-toolbar-items.top-nav(:class="{'hidden':$vuetify.breakpoint.width < 1600}")
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/dashboard`") Dashboard
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/calendar`") Calendar
		v-menu(open-on-hover bottom delay-on-close="2" transition="slide-y-transition" offset-y content-class="header__submenu" attach="#header .top-nav")
			template(v-slot:activator="{ on }")
				v-btn.font-weight-light.text-capitalize( v-on="on" flat :to="`/${role}/work/`") Work
			v-list.list--dense
				v-list-tile.font-weight-light(:to="`/${role}/work/requests`")
					v-list-tile-title Requests
				v-list-tile.font-weight-light(:to="`/${role}/work/jobs`")
					v-list-tile-title Jobs
		//- v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/reports") Reports
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/manage`") Manage
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/services`") Services
		v-menu(open-on-hover bottom delay-on-close="2" transition="slide-y-transition" offset-y content-class="header__submenu" attach="#header .top-nav")
			template(v-slot:activator="{ on }")
				v-btn.font-weight-light.text-capitalize( v-on="on" flat :to="`/${role}/profile/`") Profile
			v-list.list--dense
				v-list-tile.font-weight-light(:to="`/${role}/profile/business-summary`")
					v-list-tile-title Business Summary
				v-list-tile.font-weight-light(:to="`/${role}/profile/professional-license`")
					v-list-tile-title Professional License
				v-list-tile.font-weight-light(:to="`/${role}/profile/reviews`")
					v-list-tile-title Reviews
				v-list-tile.font-weight-light(:to="`/${role}/profile/photo-video`")
					v-list-tile-title Photo &amp; Video
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/inbox`") Inbox
		v-btn.font-weight-light.text-capitalize(flat :to="`/${role}/settings`") Settings
	v-navigation-drawer.mob-menu(v-model="drawer"  fixed light temporary height="100vh" )
		v-list.pt-0
			v-list-tile(style="padding:1px 0")
				v-btn.ma-0.drawer-close(@click.stop="drawer = !drawer" icon flat color="white")
					svg-icon(name="close" size="15px" fill="black")
			v-list-tile( :to="`/${role}/dashboard`") Dashboard
			v-list-tile( :to="`/${role}/calendar`") Calendar
			v-list-group(append-icon="")
				v-list-tile( slot="activator")
					span Work
				v-list-tile.font-weight-light(:to="`/${role}/work/requests`")
					v-list-tile-title Job Requests
				v-list-tile.font-weight-light(:to="`/${role}/work/jobs`")
					v-list-tile-title Jobs
			//- v-list-tile( :to="`/${role}/reports") Reports
			v-list-tile( :to="`/${role}/manage`") Manage
			v-list-tile( :to="`/${role}/services`") Services
			v-list-group(append-icon="")
				v-list-tile( slot="activator")
					span Profile
				v-list-tile.font-weight-light(:to="`/${role}/profile/general-info`" :hidden="$vuetify.breakpoint.width >= 1024")
					v-list-tile-title General Info
				v-list-tile.font-weight-light(:to="`/${role}/profile/business-summary`")
					v-list-tile-title Business Summary
				v-list-tile.font-weight-light(:to="`/${role}/profile/professional-license`")
					v-list-tile-title Professional License
				v-list-tile.font-weight-light(:to="`/${role}/profile/reviews`")
					v-list-tile-title Reviews
				v-list-tile.font-weight-light(:to="`/${role}/profile/photo-video`")
					v-list-tile-title Photo &amp; Video
			v-list-tile(flat :to="`/${role}/inbox`") Inbox
			v-list-tile(flat :to="`/${role}/settings`") Settings
			v-divider
			//- v-list-tile
			//- 	v-list-tile-content
			//- 		.points-box
			//- 			.points__header
			//- 				svg-icon(name="cup"  size="20px" fill="#b7c9fb")
			//- 				.points 0.00
			//- 			.points__title Available Points
	v-btn.ma-0(@click.stop="drawer = !drawer" :class="{'hidden':$vuetify.breakpoint.width >= 1600}" icon flat)
		v-icon fas fa-bars
	v-spacer
	v-flex.header__actions(shrink px-1)
		span.action
			v-btn(icon @click="toggleViewMode")
				svg-icon(name="eye" size="20px")
		span.action
			v-btn(icon )
				svg-icon(name="share"  size="20px")
		span.action
			v-badge(color="cyan" overlap)
				span(slot="badge") {{notifications}}
				v-btn(icon)
					svg-icon(name="notifications-button"  size="20px")
	v-flex.user
		v-menu(open-on-hover bottom delay-on-close="2" transition="slide-y-transition" offset-y content-class="header__submenu" attach="#header .top-nav")
			v-avatar(size="45px" v-if="$vuetify.breakpoint.width >= 1600" slot="activator")
				img(src="~@/assets/img/ava.png")
			v-list.list--dense
				v-list-tile.font-weight-light(:href="`${landingUrl}/logout`")
					v-list-tile-title Logout
		v-avatar(size="36px" v-if="$vuetify.breakpoint.width < 1600")
			img(src="~@/assets/img/ava.png")
		//- .points-box(:class="{'hidden':$vuetify.breakpoint.width < 1600}")
		//- 	.points__header
		//- 		svg-icon(name="cup"  size="20px" fill="#b7c9fb")
		//- 		.points 0.00
		//- 	.points__title Available Points
</template>
<script>
import { mapState, mapMutations } from "vuex";

export default {
	data() {
		return {
			landingUrl: `//${window.location.host}`,
			notifications: 15,
			drawer: false,
			mini: false,
			role:'provider'
		};
	},
	methods: {
		...mapMutations({
			toggleViewMode: "TOGGLE_VIEW_MODE",
		}),
	},
	computed: {
		...mapState(["user"]),
	},
	mounted() {}
};
</script>

<style lang="scss">
.header {
	z-index: 200;
	box-shadow: 0 0 15px -5px rgba(0, 0, 0, 0.15) !important;
	padding: 0 46px !important;
	.v-toolbar__content {
		@include b(1600) {
			flex-direction: row-reverse;
		}
	}
	@include b(1600) {
		padding: 0 !important;
	}
	&__submenu {
		.v-list__tile--link {
			color: currentColor;
		}
	}

	&__actions {
		margin-right: 50px;
		margin-left: auto;
		@include b(1599) {
			margin-right: 20px;
		}
		.action {
			margin: 0 10px;
			&:last-child {
				margin-right: 0;
			}
		}
		.v-btn,
		.v-badge {
			margin: 0;
		}
		.v-badge__badge {
			width: 14px;
			height: 14px;
			font-size: 9px;
			font-weight: 700;
			top: 0;
			right: 0;
			box-shadow: 0 0 0 3px #f7f8fe;
		}
	}
	.user {
		flex: 0 0 260px;
		display: flex;
		align-items: center;
		justify-content: space-between;
		@include b(1599) {
			flex-basis: auto;
		}
	}
	.points-box {
		color: #7094f7;
		.points {
			&__header {
				display: flex;
				align-items: center;
				justify-content: space-between;
				.points {
					font-size: 24px;
					font-weight: bold;
				}
			}
			&__title {
				font-size: 14px;
				font-weight: bold;
			}
		}
	}
}

.top-nav {
	.v-btn,
	.v-list__tile {
		font-size: 16px;
	}

	.v-btn--active {
		box-shadow: 0 -3px 0 #7094f7 inset;

		&:before {
			background: transparent;
		}
	}
}

.list--dense {
	.v-list__tile {
		height: 35px;
	}
}
.v-navigation-drawer {
	max-height: 100vh !important;
	z-index: 999 !important;
	position: fixed;
	overflow: auto;
	.v-list__tile--link {
		color: #1c1c1c !important;
		&.v-list__tile--active {
			color: #7094f7 !important;
		}
	}
	.v-list__group__header {
		.v-list__tile {
			overflow: visible !important;
			display: flex;
			justify-content: space-between;
			span {
				margin-right: 10px;
				line-height: 1em;
				vertical-align: middle;
				display: inline-block;
			}
			&:after {
				content: "";
				border: 1px solid #1c1c1c;
				border-width: 0 1px 1px 0;
				transform: rotate(45deg);
				display: inline-block;
				width: 8px;
				height: 8px;
				vertical-align: middle;
				font-size: 0;
				line-height: 0;
				top: -3px;
				position: relative;
				transition: all 0.15s ease-in-out;
			}
		}

		&--active {
			.v-list__tile {
				&:after {
					transform: rotate(-135deg);
					top: 3px;
				}
			}
		}
	}
}
.drawer-close {
	position: absolute;
	right: 0;
	&:hover {
		position: absolute;
	}
}
</style>
