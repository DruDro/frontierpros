<template lang="pug">
	v-app
		template(v-if="user.Id")
			appHeader
			v-content
				transition(:name="transitionName")
					router-view
			appFooter
		template(v-else)
			v-layout(align-center justify-center my-5 style="height:100%")
				v-flex(shrink )
					v-progress-circular(color="indigo lighten-4" indeterminate)
</template>

<script>
import appHeader from "./components/header";
import appFooter from "./components/footer";
import { mapState } from 'vuex';
export default {
    name: "App",
    components: {
        appHeader,
        appFooter
    },
    data() {
        return {
            transitionName: "fade"
        };
    },
    watch: {
        $route(to, from) {
            const toDepth = to.path.split("/").length;
            const fromDepth = from.path.split("/").length;
            if (toDepth < fromDepth) {
                this.transitionName = "slide-right";
            } else if (toDepth > fromDepth) {
                this.transitionName = "slide-left";
            } else {
                this.transitionName = "fade";
            }
        }
	},
	computed:{
		...mapState(['user'])
	},
    methods: {},
    mounted() {
		this.$store.dispatch("GET_USER")
			.then(()=>console.log('user logged in'))
			.catch(err=>{
				console.log('%cuser unhandled',"color:red");
				console.log(err)
				let role = "";
				if(this.$route.path.includes('provider')){
					role = 'provider'
				}
				else if(this.$route.path.includes('customer')){
					role = 'member'
				}
				window.location.href = `/login-${role}`
			})
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

 .radio-group-full-width {
   .v-input__control {
     width: 100%!important
   }
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
    opacity: 0;
}
</style>
