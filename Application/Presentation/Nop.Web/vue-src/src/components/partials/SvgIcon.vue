<template>
	<span class="icon" >
		<svg :class="className" xmlns="http://www.w3.org/2000/svg" :style="`width: ${size || width}; height: ${size || height}; min-width: ${size || width}; min-height: ${size || height}; flex-basis: ${size || width || height}!important; fill:${fill}`">
			<title v-if="title">{{ title }}</title>
			<use :xlink:href="iconPath" xmlns:xlink="http://www.w3.org/1999/xlink" />
		</svg>
	</span>
</template>

<script>
export default {

  props: {
    name: {
      type: String,
      required: true
    },

    title: {
      type: String,
      default: null
    },

    size: {
      type: String,
      default: null
    },

    width: {
      type: String,
      default: null
    },

    height: {
      type: String,
      default: null
    },

    fill: {
      type: String,
      default: null
    }
  },

  computed: {
    iconPath() {
      return require(`@/assets/icons/${this.name}.svg`).default.url;
    },

    className() {
      return 'svg-icon svg-icon--' + this.name;
	}
  }
};
</script>

<style lang="scss">
.icon{
	display: inline-block;
	max-width:100%;
	flex-shrink:0!important;
	flex-grow:0!important;
}
  .svg-icon {
    fill: currentColor;
    height: 24px;
	width: 24px;
	max-width:100%;
	max-height:100%;
	// &.gradient{
	// 	svg{
	// 		fill:url(#gradient)
	// 	}
	// }
  }
</style>
