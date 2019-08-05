<template lang="pug">
</template>

<script>
	export default {
    props: {
        pageTitle: {
            type: String
        }
    },
		data(){
			return {

			}
		},
		computed:{},
		methods:{},
		mounted(){
        this.$emit("passTitle", this.pageTitle);

		}
	}
</script>

<style lang="scss">

</style>