<template lang="pug">
v-toolbar#header.header(app color="white" :height="$vuetify.breakpoint.width >= 1600 ? 80:50")
	gradient
	v-flex( shrink mr-5 :class="{'hidden':$vuetify.breakpoint.width < 1600}")
		v-btn(icon :href="landingUrl")
			svg-icon.gradient(name="info" width="40px" height="40px")
	v-toolbar-items.top-nav(:class="{'hidden':$vuetify.breakpoint.width < 1600}")
		v-btn.font-weight-light.text-capitalize(flat to="/categories") Categories
		v-btn.font-weight-light.text-capitalize(flat to="/services") Services
</template>
<script>
import { mapState } from "vuex";
export default {
    data() {
        return {
            landingUrl: `//${window.location.host}`,
            notifications: 15,
            drawer: false,
            mini: false
        };
    },
    methods: {},
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
