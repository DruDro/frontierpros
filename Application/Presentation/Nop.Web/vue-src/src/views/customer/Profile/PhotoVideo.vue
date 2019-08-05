<template lang="pug">
.tab-content( v-resize="onResize")
	v-layout(row wrap align-center justify-space-between)
		v-flex(xs12 sm8 xl10 :class="{'pr-0 pb-4': $vuetify.breakpoint.xs, 'pr-4': $vuetify.breakpoint.smAndUp}")
			b Photo &amp; Video
			p Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit
		v-flex(xs12 sm4 xl2)
			button.btn.custom.large.primary.full-width Add New
	.profile-gallery
		v-layout(justify-space-between align-center wrap)
			v-flex(shrink)
				b 13 Photos/Videos
			v-flex(shrink)
				a.expand-gallery.font-weight-bold(:hidden="vw < 1024" @click="toggleGallery()") {{galleryExpanded ? 'Show Less':'Show All'}}
		.gallery( v-if="vw >= 1024")
			.gallery__item(v-for="(item,index) in media")
				.card
					.bg
						img(:src="`https://unsplash.it/150/300?image=${index}`" alt="")
						svg-icon.video-icon(name="video-camera" fill="#fff" size="18px" v-if="item.video")
					.info
						.delete
							v-btn(icon flat small)
								svg-icon(name="bin" fill="#fff" size="16px")
						.item-title Portrait Photography
						.description Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...
						.updated Updated 22 October 2018
		.slider-container( v-if="vw < 1024")
			slick.gallery.slider(ref="slider" :options="slickOptions" @init="handleInit")
				.gallery__item(v-for="(item,index) in media")
					.card
						.bg
							img(:src="`https://unsplash.it/150/300/?image=${index + 10}`" alt="")
							svg-icon.video-icon(name="video-camera" fill="#fff" size="18px" v-if="item.video")
						.info
							.delete
								v-btn(icon flat small)
									svg-icon(name="bin" fill="#fff" size="16px")
							.item-title Portrait Photography
							.description Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...
							.updated Updated 22 October 2018
			.slider__nav
		.extra-items.gallery(v-if="galleryExpanded && vw >= 1024")
			.gallery__item(v-for="(item,index) in extraMedia")
				.card
					.bg
						img(:src="`https://unsplash.it/150/300/?image=${index + 10}`" alt="")
						svg-icon.video-icon(name="video-camera" fill="#fff" size="18px" v-if="item.video")
					.info
						.delete
							v-btn(icon flat small)
								svg-icon(name="bin" fill="#fff" size="16px")
						.item-title Portrait Photography
						.description Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...
						.updated Updated 22 October 2018

</template>
<script>
import $ from "jquery";
import Slick from "vue-slick";
import "@/components/partials/Slider.scss";
export default {
	components:{
		'slick':Slick
	},
    props: {
        pageTitle: {
            type: String
        }
    },
    data() {
        return {
			media:[
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
			],
			extraMedia:[
				{
					video:true
				},
				
				{
				},
				
				{
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
					video:true
				},
				
				{
				},
				
				{
				},
				
				{
					video:true
				},
				
			],
            vw: 0,
            slickOptions: {
                dots: true,
                infinite: false,
                speed: 300,
                prevArrow:
                    '<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
                nextArrow:
                    '<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
                appendArrows: ".slider__nav",
                appendDots: ".slider__nav",
                slidesToShow: 3,
				slidesToScroll: 3,
				responsive: [
					{
						breakpoint: 940,
						settings: {
							slidesToShow: 2,
							slidesToScroll: 2
						}
					},
					{
						breakpoint: 640,
						settings: {
							slidesToShow: 1,
							slidesToScroll: 1
						}
					},
				]
            },
            galleryExpanded: false
        };
    },
    methods: {
        handleInit(event, slick) {
            slick.goTo(slick.currentSlide);
        },
        toggleGallery: function() {
            this.galleryExpanded = !this.galleryExpanded;
        },
        onResize() {
            this.vw = window.innerWidth;
        }
    },
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>

<style lang="scss">
.profile-gallery {
    margin: 30px 0 0;
    .expand-gallery {
        position: relative;

        &:after {
            content: "";
            position: relative;
            width: 12px;
            height: 12px;
            font-size: 18px;
            vertical-align: middle;
            color: currentColor;
            border-style: solid;
            border-width: 1px 1px 0 0;
            background-color: currentColor currentColor transparent transparent;
            display: inline-block;
            transform: rotate(135deg);
            top: -4px;
            margin-left: 5px;
        }
    }
}
.gallery {
    display: flex;
    flex-flow: row wrap;
	margin: 20px -10px 0;
        justify-content: space-between;
    @include b(1599) {
        justify-content: space-evenly;
    }
    &__item {
        margin: 15px 10px;
        width: 260px;
        box-shadow: 0px 15px 30px 0px rgba(10, 15, 67, 0.11);
        border-radius: 20px;
		overflow: hidden;

        .card {
            margin: 0 auto;
            position: relative;
            width: 260px;
            height: 250px;
            transition: all 0.15s ease-in-out;

            .bg {
                position: absolute;
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;

                img {
                    position: absolute;
                    left: 50%;
                    top: 50%;
                    min-width: 100%;
                    min-height: 100%;
                    transform: translate(-50%, -50%);
                    border-radius: 20px;
                }
                .video-icon {
                    position: absolute;
                    left: 10px;
                    bottom: 10px;
                    width: 30px;
                    height: 30px;
                    border-radius: 50%;
                    background: #7094f7;
                    text-align: center;
                    display: block;
                    svg {
                        position: absolute;
                        top: 50%;
                        left: 50%;
                        transform: translate(-50%, -50%);
                    }
                }
            }

            .info {
                opacity: 0;
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;
                position: absolute;
                background: #7094f7;
                color: #fff;
                transition: all 0.15s ease-in-out;
                text-align: center;
                padding: 20px;
                .item-title {
                    font-size: 18px;
                    font-weight: bold;
                    padding: 0 40px 15px;
                }
                .description {
                    font-size: 18px;
                    font-weight: 300;
                    line-height: normal;
                }
                .updated {
                    font-size: 18px;
                    font-weight: 400;
                    position: absolute;
                    width: 100%;
                    bottom: 10px;
                    left: 0;
                    white-space: nowrap;
                }
                .delete {
                    position: absolute;
                    right: 15px;
                    top: 10px;
                }
            }

            &:hover {
                .info {
                    opacity: 1;
                }
            }
        }
    }
	&.slider{
		display:block;
		.slick-track{
		}
		.slick-slide{
			margin:0 20px;
		}
		.gallery__item{
			box-shadow: none;
			overflow:visible;
			padding: 0 0 30px 0;
			margin:0;
			.card{
        		box-shadow: 0px 15px 30px 0px rgba(10, 15, 67, 0.11);
			}
		}
	}
}
</style>
