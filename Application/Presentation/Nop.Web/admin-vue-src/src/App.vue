<template lang="pug">
	v-app
		v-navigation-drawer(v-model="drawer" fixed  light  app)
			v-list
				v-list-tile(to="/categories")
					v-list-tile-content
						v-list-tile-title Categories
				v-list-tile(to="/services")
					v-list-tile-content
						v-list-tile-title Services
		v-toolbar(app color="white" :height="$vuetify.breakpoint.width >= 1600 ? 80:50")
			gradient
			v-toolbar-side-icon(@click.stop="drawer = !drawer")
			v-toolbar-items.top-nav(:class="{'hidden':$vuetify.breakpoint.width < 1600}")
				v-btn.font-weight-light.text-capitalize(flat to="/categories") Categories
				v-btn.font-weight-light.text-capitalize(flat to="/services") Services
			v-spacer
			v-flex( shrink mr-5 :class="{'hidden':$vuetify.breakpoint.width < 1600}")
				v-btn(icon :href="landingUrl")
					svg-icon.gradient(name="info" width="40px" height="40px")
		v-content
			transition(:name="transitionName")
				router-view
</template>

<script>
import { mapState } from "vuex";
export default {
    name: "App",
    data() {
        return {
			transitionName:'fade',
            landingUrl: `//${window.location.host}`,
            drawer: false,
            mini: false
		};
    },
    watch: {
        $route(to, from) {
            const toDepth = to.path.split("/").length;
			const fromDepth = from.path.split("/").length;
			if(toDepth < fromDepth){
				this.transitionName = "slide-right"
			}
			else if(toDepth > fromDepth){
				this.transitionName = "slide-left"
			}
			else {
				this.transitionName = "fade"
			}
        }
    },
    computed: {
        ...mapState(["userModule/user"]),
        role: function() {
            if (this.user.roles) {
                if (this.user.roles.includes("Members")) {
                    return "customer";
                }
                else if (this.user.roles.includes("Providers")) {
                    return "provider";
                }
                else if (this.user.roles.includes("ServiceProviders")) {
                    return "service-provider";
                }
            }
        }
    },
    methods: {},
    mounted() {
        this.$store.dispatch("GET_USER");
    }
};
</script>
<style lang="scss">
body,
.application {
    background: #f6f8fe !important;
}
.hidden {
    display: none !important;
}
.visible {
    display: block !important;
}
.v-btn {
    font-size: 18px;
}
.container {
    @include b(tablet) {
        padding: 0 15px;
        @at-root .card & {
            padding: 0;
        }
    }
}
.v-text-field label {
    font-size: 18px;
    font-weight: bold;
    color: #1c1c1c !important;
}

.v-text-field input {
    font-size: 18px;
    font-weight: 300;
    color: #1c1c1c !important;
}

.custom--round {
    .v-input__slot {
        border-radius: 10px !important;
        border-width: 1px !important;
        border-style: solid !important;
        border-radius: 5px !important;
    }

    @at-root label + & {
        margin-top: 10px !important;
        textarea {
            margin-top: 10px !important;
        }
    }
}



.slide-left-enter-active,
.slide-left-leave-active,
.slide-right-enter-active,
.slide-right-leave-active {
  transition-duration: 0.5s;
  transition-property: height, opacity, transform;
  transition-timing-function: cubic-bezier(0.55, 0, 0.1, 1);
  overflow: hidden;
}

.slide-left-enter,
.slide-right-leave-active {
  opacity: 0;
  transform: translate(2em, 0);
}

.slide-left-leave-active,
.slide-right-enter {
  opacity: 0;
  transform: translate(-2em, 0);
}


.fade-enter-active,
.fade-leave-active {
  transition-duration: 0.3s;
  transition-property: opacity;
  transition-timing-function: ease;
}

.fade-enter,
.fade-leave-active {
  opacity: 0
}

.v-expansion-panel li{
	padding:0;
	&:before{
		display: none;
	}
}





.header {
    z-index: 200;
    box-shadow: 0 0 15px -5px rgba(0, 0, 0, 0.15) !important;
    padding: 0 46px !important;
    &__submenu {
        .v-list__tile--link {
            color: currentColor;
        }
    }

    &__actions {
        margin-right: 50px;
        margin-left: auto;
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
