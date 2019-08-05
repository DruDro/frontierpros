<template lang="pug">
	.card
		slot
</template>
<style lang="scss">
.card {
    background-color: #fff;
    background-position: right top;
    background-repeat: no-repeat;
    background-size: contain;
    padding: 15px 30px;
    box-shadow: 0 15px 30px rgba(#7498fc, 0.1)!important;
	border-radius: 20px;
	@include b(tablet){
		padding:15px;
	}
    &.bg {
        background-image: url(~@/assets/img/card-bg.png);
    }
    & + & {
        margin-top: 40px;
    }
}
</style>
