<template lang="pug">
v-flex.page-sidebar()
	#chaat.chat(:hidden="$vuetify.breakpoint.width < 1024")
		v-badge(color="white")
			v-avatar.raised(size="86" color="primary" v-ripple)
				svg-icon(name="talk" size="40px" fill="#fff")
			span(slot="badge") 1
	.sidebar__title TEAM
	v-form
		v-layout(row nowrap align-center)
			v-flex(grow)
				v-text-field(label="Enter Name")
			v-flex(shrink)
				v-btn(icon)
					svg-icon(name="plus" size="25px" fill="#7094f7")
	.service__team
		.teammate(v-for="i in 3")
			a.remove(href="#" v-ripple)
				svg-icon(name="close" size="14px" fill="#7094f7")
			v-avatar(size="50")
				img(src="~@/assets/img/ava.png")
			.teammate__info
				.name Melissa Dunn
				.pos Developer
			a.see(href="#" v-ripple)
				svg-icon(name="eye" width="19px" height="15px" fill="#7094f7")
</template>
<script>
export default {
    props: {
        pageTitle: {
            type: String
		}
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>
<style lang="scss">
.service__team{
	.teammate{
		display:flex;
		flex-flow:row nowrap;
		align-items:center;
		justify-content:space-between;
		padding:10px 0 20px;
		margin:0 0 10px 0;
		border-bottom: 1px solid rgba(28,28,28,.2);
		&:last-child{
			border-bottom: 0;
		}
		.remove{
			margin:0 10px 0 0;
			font-size: 0;
			line-height: 0;
			padding:5px;
			border-radius: 50%;
		}
		.see{
			margin:0 0 0 10px;
			font-size: 0;
			line-height: 0;
			padding:5px;
			border-radius: 50%;
			align-self: flex-start;
			opacity:.5;
			&:hover{
				opacity:1
			}
		}
		&__info{
			margin-left: 10px;
			align-self: flex-start;
			.name{
				font-size: 16px;
				font-weight: bold;
			}
			.pos{
				font-size: 16px;
				font-weight: 300;
				}
		}
	}
}
</style>
