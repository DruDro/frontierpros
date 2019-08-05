<template>
    <label class="radiobox" :for="id" :class="{'disabled': disabled}"> {{ label }}
        <input type="radio" :name="name" :id="id" :checked="checked" :disabled="disabled">
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
		disabled:{
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
	.radiobox{
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
			border-radius:50%;
			position: absolute;
			width:100%;
			height: 100%;
			top:0;
			left:0;
			border:1px solid #7094f7;
			z-index:1;
			display: block;
			transition:all .15s ease-in-out;
		}
		input:checked + .check{
			background: #7094f7;
			box-shadow:0 0 0 2px #fff inset;
			&:before{				
				opacity:1;
			}
		}
		&.disabled{
			opacity:.2
		}
	}
</style>
