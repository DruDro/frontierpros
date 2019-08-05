<template lang="pug">
.tab-content( v-resize="onResize")
	v-layout(row wrap align-center justify-space-between )
		v-flex(xs12 sm8 xl10 :class="{'pr-0 pb-4': $vuetify.breakpoint.xs, 'pr-4': $vuetify.breakpoint.smAndUp}")
			b Reviews{{ vw }}
			p Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit
		v-flex(xs12 sm4 xl2)
			button.btn.custom.large.primary.full-width Get Request
	.reviews-summary.card
		.rating
			.total 4.3
			.stars
				i.star.fas.fa-star
				i.star.fas.fa-star
				i.star.fas.fa-star
				i.star.fas.fa-star
				i.star.fas.fa-star-half-alt
			.total-reviews 12 reviews
		.rating-overview
			.total-marks( v-for="r in rating")
				.value {{r.value}}
				.star
					i.fas.fa-star
				.percent-line
					.fill(:style="`width:${r.percent}%`")
				.percent {{r.percent}}%
		.review-letter
			h4 Review Letter
			p Thanks for being a valued customer. I just signed up on FrontierPros to find more excellent customers like you, and reviews are a big part of my profile. Can you take a moment to write a couple sentences about working with me? I’d love if my future customers could hear about your experience firsthand.
				br
				br
				| Thanks, Daryl Computer repair
	.profile-reviews
		v-layout(justify-space-between align-center)
			v-flex(shrink)
				b 12 Reviews
			v-flex(shrink)
				a.expand-reviews.font-weight-bold(@click="toggleReviews()" :hidden="vw < 1024") {{reviewsExpanded ? 'Show Less':'Show All'}}
		.slider-container(v-if="vw < 1023")
			slick#reviewsSlider.reviews.mt-4.slider(ref="slider" :options="slickOptions" @init="handleInit")
				.card.review(v-for="review in extraReviews")
					.review__author
						v-avatar.author__ava(size="85")
							img(src="~@/assets/img/ava.png")
						.author__details
							.name Larry Perez
							.rating
								span 5.0
								span.stars
									i.star.fas.fa-star
									i.star.fas.fa-star
									i.star.fas.fa-star
									i.star.fas.fa-star
									i.star.fas.fa-star
							.date 21 November 2018
					.review__content
						.review__title Review
						.review__text Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
							
			.slider__nav.slider-container
		.reviews.mt-4(v-if="vw >= 1024")
			.card.review(v-for="review in reviews")
				.review__author
					v-avatar.author__ava(size="85")
						img(src="~@/assets/img/ava.png")
					.author__details
						.name Larry Perez
						.rating
							span 5.0
							span.stars
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
						.date 21 November 2018
				.review__content
					.review__title Review
					.review__text Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
		.extra-items.reviews.mt-5(v-if="reviewsExpanded" :hidden="vw < 1024")
			.card.review(v-for="i in 9")
				.review__author
					v-avatar.author__ava(size="85")
						img(src="~@/assets/img/ava.png")
					.author__details
						.name Larry Perez
						.rating
							span 5.0
							span.stars
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
								i.star.fas.fa-star
						.date 21 November 2018
				.review__content
					.review__title Review
					.review__text Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.

</template>
<script>
import $ from "jquery";
import Slick from "vue-slick";
import "@/components/partials/Slider.scss";
export default {
    components: {
        slick: Slick
    },
    props: {
        pageTitle: {
            type: String
        }
    },
    data() {
        return {
			reviews: 3,
			extraReviews:12,
            vw: 0,
            reviewsExpanded: false,
            rating: [
                { value: 5, percent: 96 },
                { value: 4, percent: 10 },
                { value: 3, percent: 25 },
                { value: 2, percent: 7 },
                { value: 1, percent: 12 }
            ],
            slickOptions: {
                dots: true,
                infinite: false,
                speed: 300,
                swipeToSlide: true,
                prevArrow:
                    '<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',
                nextArrow:
                    '<span class="next"><i class="icon fas fa-chevron-right"></i></span>',
                appendArrows: ".slider__nav",
                appendDots: ".slider__nav",
                slidesToShow: 1,
                slidesToScroll: 1
            }
        };
    },
    methods: {
        handleInit(event, slick) {
            slick.goTo(slick.currentSlide);
        },
        toggleReviews: function() {
            this.reviewsExpanded = !this.reviewsExpanded;
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
.reviews-summary {
    flex-flow: row nowrap;
    align-items: center;
    justify-content: center;
    display: flex;
    margin: 30px 0;
    @include b(1600) {
        flex-wrap: wrap;
    }
    .rating {
        text-align: center;
        flex: 0 0 130px;
        padding-top: 15px;
        padding-bottom: 15px;
        .total {
            color: #fdba06;
            font-size: 75px;
            font-weight: bold;
            line-height: 1em;
        }
        .stars {
            font-size: 14px;
            .star {
                margin: 0 2px;
            }
        }
        .total-reviews {
            font-size: 24px;
            font-weight: 400;
        }
    }
    .rating-overview {
        flex: 0 0 270px;
        max-width: 100%;
        margin: 15px 30px;
        @include b(mobile) {
            margin: 15px 0;
        }
        .total-marks {
            display: flex;
            align-items: center;
            justify-content: stretch;
            .value {
                font-size: 18px;
                font-weight: 400;
            }
            .star {
                color: #fdba06;
                margin-left: 5px;
                font-size: 14px;
            }
            .percent-line {
                position: relative;
                background: #e2eafd;
                height: 7px;
                flex: 0 0 150px;
                border-radius: 7px;
                margin: 0 25px;
                .fill {
                    position: absolute;
                    background: #7094f7;
                    height: 100%;
                    border-radius: 7px;
                }
            }
            .percent {
                text-align: center;
                flex: 1 1 auto;
                font-size: 18px;
                font-weight: 400;
            }
        }
    }
    .review-letter {
        flex: 1 1 auto;
        text-align: center;
        padding-top: 15px;
        padding-bottom: 15px;
    }
}
.profile-reviews {
    .expand-reviews {
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
    .reviews {
        .review {
            padding: 30px;
			height: auto;
			
            &__author {
                display: flex;
                align-items: center;
                flex-flow: row wrap;
                .author {
                    &__ava {
                        margin: 10px 40px 10px 0 !important;
                    }
                    &__details {
                        margin: 10px 0;
                        .name {
                            font-size: 24px;
                            font-weight: bold;
                        }
                        .rating {
                            font-size: 18px;
                            font-weight: bold;
                            color: #fdba06;
                            margin: 10px 0;
                            .stars {
                                margin: 0 0 0 10px;
                                .star {
                                    margin: 0 2px;
                                }
                            }
                        }
                        .date {
                        }
                    }
                }
            }
            &__content {
            }
            &__title {
                font-weight: bold;
                padding-bottom: 10px;
            }
            &__text {
                font-size: 14px;
                color: #777;
                line-height: 1.2;
            }
        }
    }
}
</style>
