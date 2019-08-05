<template>
    <label class="switch" :for="id" @click.prevent>
        <input type="checkbox" :name="name" :id="id"  :checked="checked">
        <span class="switcher" :class="type"></span>
    </label>
</template>
<script>
export default {
    props: {
		onClick: {
			type: Object
		},
        name: {
            type: String,
            default: null
        },
        id: {
            type: String,
            default: null
		},
		checked:{
			type:Boolean,
			default:false
		},
		type:{
			type:String,
			default:'round'
		}
	},
	computed:{
	}
};
</script>

<style lang="scss">
.switch {
    position: relative;
    display: inline-block;
    width: 45px;
    height: 20px;
}

.switch input {
    opacity: 0;
    width: 0;
    height: 0;
}

.switcher {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #e8e8e8;
    -webkit-transition: 0.4s;
    transition: 0.4s;
}

.switcher:before {
    position: absolute;
    content: "";
    height: 24px;
    width: 24px;
	left: 0;
	top:-2px;
	border:1px solid #d5d5d5;
    background-color: white;
    -webkit-transition: 0.4s;
    transition: 0.15s;
}


input:checked + .switcher:before {
    transform: translateX(21px);
    background-color: #e47fa7;
	box-shadow: 0 0 0 5px rgba(#e47fa7,.5);
	border:0;
}

/* Rounded switchers */
.switcher.round {
    border-radius: 10px;
}

.switcher.round:before {
    border-radius: 50%;
}

.green-pink{
	.switcher:before {
		border:1px solid #e47fa7;
		background-color: #e47fa7;
		box-shadow: 0 0 0 5px rgba(#e47fa7,.5);
	}
	input:checked + .switcher:before {
		background-color: #18c3c8;
		box-shadow: 0 0 0 5px rgba(#18c3c8,.5);
	}
}
</style>
