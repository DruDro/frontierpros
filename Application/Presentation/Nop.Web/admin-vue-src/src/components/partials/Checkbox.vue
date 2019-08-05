<template>
    <label class="checkbox" :for="id"> {{ label }}
        <input type="checkbox" :name="name" :id="id" :checked="checked">
        <span class="check" :class="type"></span>
    </label>
</template>
<script>
export default {
    props: {
        name: {
            type: String,
            default: null
        },
        id: {
            type: String,
            default: null
		},
		color:{
			type:String,
			default:null
		},
		checked:{
			type:Boolean,
			default:false
		},
		type:{
			type:String,
			default:'round'
		},
		label:{
			type:String
		}
    }
};
</script>

<style lang="scss">
	.checkbox{
		position: relative;
		width: 24px;
		height: 24px;
		background: transparent;
		border-radius:3px;
		display: block;
		cursor: pointer;
		&.sm{
			width: 16px;
			height: 16px;
		}
		input{
			display: none;
			appearance:none;
		}
		.check{
			border-radius:3px;
			position: absolute;
			width:100%;
			height: 100%;
			top:0;
			left:0;
			border:1px solid #1d2284;
			z-index:1;
			display: block;
			transition:all .15s ease-in-out;
			&:before{
				content:"";
				width:10px;
				height: 6px;
				border:2px solid #fff;
				border-top:0;
				border-right:0;
				transform:rotate(-45deg) translate(-50%,-50%);
				transform-origin: 0 0;
				position: absolute;
				top:50%;
				left:50%;
				margin-top: -2px;
				display: block;
				opacity:0;
			}
		}
		input:checked + .check{
			border:0;
			background: #7094f7;
			&:before{				
				opacity:1;
			}
		}
		&.round{
			border-radius:50%;
			.check{
				border-radius:50%;
			}
		}
	}
</style>
