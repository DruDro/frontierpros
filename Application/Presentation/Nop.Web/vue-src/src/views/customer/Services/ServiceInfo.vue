<template lang="pug">
.tab-content(v-resize="onResize")
	v-layout(row :wrap="$vuetify.breakpoint.smAndDown" align-start justify-center)
		v-flex.service__ava(shrink mb-4)
			v-badge(bottom overlap )
				v-img(aspect-ratio="1" width="260" src="http://placehold.it/2000x1000")
				v-btn.ma-0(icon slot="badge")
					svg-icon(name="pencil" size="20px" fill="white")
			div
				v-btn.btn.transparent.custom.capitalize.mt-4(flat color="primary")
					svg-icon.mr-2(size="20px"  name="plus")
					| Add New Promotion
		v-flex(grow :class="{'ml-4': $vuetify.breakpoint.mdAndUp,'xs12': $vuetify.breakpoint.smAndDown}")
			card.py-0.px-3
				v-form
					v-container(fluid grid-list-xl)
						v-layout(row wrap )
							v-flex
								label.font-weight-bold Service Name
								v-text-field(label="" placeholder="Service Name")
							v-flex
								label.font-weight-bold Service Category
								v-text-field(label="" placeholder="Service Category")
						label.font-weight-bold Description
						v-textarea.custom--round(
							rows="7"
							outline
							value="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. /nExcepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam")
	//- v-layout.service__discount(
	//- 	pa-3
	//- 	my-5
	//- 	row
	//- 	nowrap
	//- 	align-center
	//- 	justify-start)
	//- 	v-flex.discount__icon(shrink)
	//- 		svg-icon(name="discount" size="75px" fill="rgba(255,255,255,0.3)")
	//- 	v-flex.discount__title(
	//- 		ml-4
	//- 		shrink
	//- 		style="white-space:normal") Discount on this service until December&nbsp;1
	//- 	v-flex.discount__amount(
	//- 		ml-auto
	//- 		mr-5
	//- 		shrink) 20%
	//- 	v-layout.flex.discount__actions(shrink  nowrap ma-0)
	//- 		v-btn.ma-0(icon flat)
	//- 			svg-icon(name="pencil" size="13px" fill="rgba(255,255,255,0.3)")
	//- 		v-btn.ma-0(icon flat)
	//- 			svg-icon(name="bin" size="13px" fill="rgba(255,255,255,0.3)")
	h3.mt-5.mb-2 Set Your Travel Areas for Computer Repair
	p.mb-4 Choose areas from the list or set by distance you`re willing to trevel.
	card
		.v-input.v-text-field
			.v-input__control
				v-layout(row nowrap justify-space-between)
					v-flex.mb-2(shrink)
						label.v-label Description
					v-flex.mb-2(shrink)
						label.v-label() {{preferredDistance}} km from you
				vue-slider.distance-slider.px-0(height="3" v-model="preferredDistance" tooltip="false")
		h3.mt-4 Specific Areas
		ul.mt-4.raised-dots
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Northeast Dallas Suburbs
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Plano, McKinney, Garland, Allen
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Northeast Dallas Suburbs
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Carrolton, Coppell, Lewisville, Denton, Carrolton, Coppell
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Dallas
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Downtown - Central Dallas, North Dallas, East Dallas, South Dallas, Downtown - Central Dallas, North Dallas, East Dallas, South Dallas
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Rockwall Country
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Fate, Rockwall, Royse City
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 East Dallas Suburbs
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Mesquite, Seagowile, Balch Springs, Carrolton, Coppell
	h3.mt-5 Photos & Videos
	h4.mt-3 Show Off Your Business
	p Include photos of your work (before and after), team, workspace, or equipment.
	.slider-container.mb-5
		slick.gallery.slider(
			ref="slick"
			:options="slickOptions"
			@init="handleInit")
			.gallery__item(v-for="(item,index) in media")
				.card
					.bg
						img(
							:src="`https://unsplash.it/150/300/?image=${index + 10}`"
							alt="")
						svg-icon.video-icon(
							v-if="item.video"
							name="video-camera"
							fill="#fff"
							size="18px")
					.info
						.delete
							v-btn(icon flat small)
								svg-icon(name="bin" fill="#fff" size="16px")
						.item-title Portrait Photography
						.description Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...
						.updated Updated 22 October 2018
		.slider__nav
	card.service__business-hours
		v-layout.page-header(
			mt-4
			row
			wrap
			align-center
			justify-space-between)
			v-flex.pa-0.ma-0(
				tag="h3" 
				grow
				:class="{'mr-4 shrink':$vuetify.breakpoint.smAndUp,'mb-3 xs12 grow':$vuetify.breakpoint.xs}" ) Business Hours
			//- v-flex.tabs(shrink mb-2 :class="{'shrink':$vuetify.breakpoint.smAndUp,'mb-3 grow xs12':$vuetify.breakpoint.xs}"  )
			//- 	v-layout(row)
			//- 		v-flex
			//- 			a.btn.custom.full-width.router-link-active( href="#" ) Regular
			//- 		v-flex
			//- 			a.btn.custom.full-width( href="#" ) VIP
		p Click on the day of the week to select, click again to cancel the selection
		v-container(mt-4 pa-0 grid-list-xl fluid)
			v-layout(row wrap ma-0)
				v-flex(lg8 xs12 pa-0)
					v-container(pa-0 grid-list-xl fluid)
						v-layout.service__days(row nowrap justify-stretch ma-0)
							v-flex.service__day.text-center(v-ripple grow v-for="(day,index) in days" :key="index")
								input(
									type="checkbox"
									name="day"
									:id="day.value" )
								label(:for="day.value") {{day.text}}
						v-layout(row :wrap="$vuetify.breakpoint.xs" mt-3)
							v-flex()
								label.font-weight-bold Begin Hours
								v-menu(
									ref="menu"
									v-model="menu"
									:close-on-content-click="false"
									lazy
									transition="scale-transition"
									z-index="99"
									offset-y
									full-width
									max-width="290px"
									min-width="290px")
									v-text-field(
										slot="activator"
										:value="time | formatTime"
										label=""
										readonly)
									v-time-picker(
										v-model="time"
										full-width
										rollable)
							v-flex(sm7 xs12)
								label.font-weight-bold Time Zone
								v-select(
									z-index="99"
									offset-y
									label=""
									v-model="tz"
									:items="timezones"
									append-icon="")
						v-layout(row  :wrap="$vuetify.breakpoint.xs")
							v-flex()
								label.font-weight-bold Finish Hours
								v-menu(
									ref="menu2"
									v-model="menu2"
									:close-on-content-click="false"
									lazy
									transition="scale-transition"
									z-index="99"
									offset-y
									full-width
									max-width="290px"
									min-width="290px")
									v-text-field(
										slot="activator"
										:value="time2 | formatTime"
										label=""
										readonly)
									v-time-picker(
										v-model="time2"
										full-width
										rollable)
							v-flex(sm7 xs12)
								label.font-weight-bold Project Duration
								v-text-field(label="" placeholder="e.g. 24 Hours")
				v-flex(lg4 xs12 pa-0 :mt-3="$vuetify.breakpoint.mdAndDown" :pl-5="$vuetify.breakpoint.lgAndUp")
					h4.question.py-0 How Much Notice do You Need Before Doing a Job?
					v-layout()
						v-flex(py-0)
							v-text-field(
								value="3"
								hide-details=true
								type="number")
						v-flex(py-0)
							v-select(
								:items="noticeRange"
								v-model="noticeRangeSelected"
								offset-y
								append-icon=""
								hide-details=true)
					h4.question.mt-4.py-0 How Far in Advance Can Customers Book you for a Job?
					v-layout()
						v-flex(py-0)
							v-text-field(
								hide-details=true
								type="number"
								value="3")
						v-flex(py-0)
							v-select(
								offset-y
								:items="bookRange"
								v-model="bookRangeSelected"
								append-icon=""
								hide-details=true)
					v-layout(mt-2 my-0 row nowrap align-center)
						v-flex(shrink)
							checkbox.sm(v-model="availability" id="availability")
						v-flex(shrink)
							label.subheading(style="line-height:1.2;display:block" for="availability") My avalibility is flexible. Match me with as many jobs as possible.
	//- card
		v-layout.page-header(
			mt-4
			row
			wrap
			align-center
			justify-space-between)
			v-flex(
				pa-0
				ma-0
				mb-2
				:class="{'mr-4 shrink':$vuetify.breakpoint.smAndUp,'mb-3 xs12 grow':$vuetify.breakpoint.xs}" )
				v-layout.setting(
					align-center
					nowrap)
					v-flex(tag="label" for="sw" shrink mr-auto) Autobooked
					switcher.green-pink.flex.mx-3.shrink(
						id="sw"
						shrink
						:checked="autobooked"
						@click.native="autobooked = !autobooked")
					v-flex( shrink)
						v-tooltip(top light color="white" )
							svg-icon(
								name="info-circle"
								fill="#7094f7"
								size="16px"
								slot="activator")
							span.c-black When auto booking is enabled, the job will automatically appear in our calendar and in the Job list. 
			v-flex.tabs(mb-2 :class="{'shrink':$vuetify.breakpoint.smAndUp,'mb-3 grow xs12':$vuetify.breakpoint.xs}"  )
				v-layout(row)
					v-flex
						a.btn.custom.full-width.router-link-active( href="#" ) Regular
					v-flex
						a.btn.custom.full-width( href="#" ) VIP
		v-divider
		label.font-weight-bold Date
		v-container(fluid pa-0 ma-0 grid-list-xl)
			v-layout(row wrap)
				v-flex
					v-layout(row nowrap align-end)
						v-flex(tag="label" shrink) Begin
						v-flex
							v-text-field.pa-0.ma-0(
								hide-details=true
								:value="serviceRange.begin | formatDate")
						v-flex(shrink)
							v-menu( 
								z-index="99"
								offset-y
								full-width
								max-width="290px"
								min-width="290px"
								v-model="menu3")
								svg-icon(
									name="calendar"
									slot="activator"
									fill="rgb(112, 148, 247)"
									size="21px")
								v-date-picker(v-model="serviceRange.begin ")
				v-flex()
					v-layout(row nowrap align-end)
						v-flex(tag="label" shrink) Finish
						v-flex
							v-text-field.pa-0.ma-0(
								hide-details=true
								:value="serviceRange.end | formatDate")
						v-flex(shrink)
							v-menu(
								z-index="99"
								offset-y
								full-width
								max-width="290px"
								min-width="290px"
								v-model="menu4")
								svg-icon(
									name="calendar"
									slot="activator"
									fill="rgb(112, 148, 247)"
									size="21px")
								v-date-picker(v-model="serviceRange.end ")
		label.d-block.font-weight-bold.mt-5.mb-2 Time/Slot(s)
		.service__slots.mb-3(v-for="(slot, index) in slots")
			label.d-block.ma-0 {{slot.slot}}
			v-container.pa-0.ma-0(
				:grid-list-xl="$vuetify.breakpoint.lgAndUp"
				:grid-list-sm="$vuetify.breakpoint.mdAndDown"
				fluid)
				v-layout.my-0.slot__row(
					:mb-2="$vuetify.breakpoint.mdAndDown"
					row
					wrap
					justify-center
					align-center
					v-for="(row,i) in slot.rows" :key="i")
					v-flex(grow :mb-2="$vuetify.breakpoint.mdAndDown")
						.slot.round.range
							v-layout.text-xs-left(
								ma-0
								align-center
								justify-center
								nowrap)
								v-flex(pa-0 shrink :class="{'mr-3':$vuetify.breakpoint.lgAndUp}" mr-1)
									svg-icon(name="clock" size="14px" fill="#fff")
								v-flex.text-no-wrap(pa-0) {{row.range.from | formatTime }}
								v-flex(pa-0 mx-md-3 mx-1 ) till
								v-flex(pa-0 shrink :class="{'mr-3':$vuetify.breakpoint.lgAndUp}" mr-1)
									svg-icon(name="clock" size="14px" fill="#fff")
								v-flex.text-no-wrap(pa-0 shrink) {{row.range.till | formatTime }}
					v-flex(
						tag="v-layout"
						pa-0
						ma-0
						row
						wrap
						grow 
						:xs12="$vuetify.breakpoint.smAndDown")
						v-flex(grow :mb-2="$vuetify.breakpoint.mdAndDown" :xs12="$vuetify.breakpoint.smAndDown")
							.slot.blocked 20 slots blocked
						v-flex(grow :mb-2="$vuetify.breakpoint.mdAndDown")
							.slot.open 35 slots open
					v-flex( :mb-2="$vuetify.breakpoint.mdAndDown")
						v-layout(row nowrap align-center justify-center)
							v-flex()
								.slot.del.align-center.justify-center(
									v-ripple
									style="display:flex")
									svg-icon.pa-0.ma-0.mr-3(
										name="minus"
										size="21px")
									v-flex(pa-0 ma-0 shrink) Del
							v-flex()
								.slot.add.align-center.justify-center(
									v-ripple 
									style="display:flex")
									svg-icon.pa-0.ma-0.mr-3(
										name="plus"
										size="21px")
									v-flex(pa-0 ma-0 shrink) Add
	card
		h3 Specialities
		ul.mt-4.raised-dots.top-dots
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Computer Issue
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Slow computer performance
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Virus or malware
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Troubleshooting needed to determine issue
			li.ma-0.pa-0.mb-3.pl-4
				h4.ma-0.pa-0 Computer Type
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light PC
				p.ma-0.pa-0.grey--text.text--darken-3.font-weight-light Mac (Apple)
</template>
<script>
import Slick from "vue-slick";
import vueSlider from "vue-slider-component";
import moment from "moment";
import "@/components/partials/Slider.scss";
export default {
    components: {
        Slick,
        "vue-slider": vueSlider
    },
    props: {
        pageTitle: {
            type: String
        }
    },
    data() {
        return {
            time: "00:00",
            time2: "00:00",
            serviceRange: {
                begin: moment().format("YYYY-MM-DD"),
                end: moment().format("YYYY-MM-DD")
            },
            tz: {
                text: "Central Time",
                value: "CST"
            },
            timezones: [
                {
                    text: "Eastern Standard Time",
                    value: "EST"
                },
                {
                    text: "Central Time",
                    value: "CST"
                }
			],
			bookRangeSelected:{text:"Months",value:"months"},
			bookRange:[{text:"Months",value:"months"},{text:"Weeks",value:"weeks"}],
			noticeRangeSelected:{text:"Days",value:"days"},
			noticeRange:[{text:"Days",value:"days"},{text:"Weeks",value:"weeks"}],
            slots: [
                {
                    slot: "Morning",
                    rows: [
                        {
                            range: {
                                from: "08:00",
                                till: "09:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "09:00",
                                till: "10:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "10:00",
                                till: "11:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "11:00",
                                till: "12:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "12:00",
                                till: "13:00"
                            },
                            blocked: 20,
                            open: 35
                        }
                    ]
                },
                {
                    slot: "Afternoon",
                    rows: [
                        {
                            range: {
                                from: "13:00",
                                till: "14:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "14:00",
                                till: "15:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "15:00",
                                till: "16:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "16:00",
                                till: "17:00"
                            },
                            blocked: 20,
                            open: 35
                        },
                        {
                            range: {
                                from: "17:00",
                                till: "18:00"
                            },
                            blocked: 20,
                            open: 35
                        }
                    ]
                },
                {
                    slot: "Evening",
                    rows: [
                        {
                            range: {
                                from: "18:00",
                                till: "19:00"
                            },
                            blocked: 20,
                            open: 35
                        }
                    ]
                }
            ],
            days: [
                {
                    text: "Sun",
                    value: "sun"
                },
                {
                    text: "Mon",
                    value: "mon"
                },
                {
                    text: "Tue",
                    value: "tue"
                },
                {
                    text: "Wed",
                    value: "wed"
                },
                {
                    text: "Thu",
                    value: "thu"
                },
                {
                    text: "Fri",
                    value: "fri"
                },
                {
                    text: "Sat",
                    value: "sat"
                }
            ],
            autobooked: false,
            tooltip: false,
            availability: true,
            menu: false,
            menu2: false,
            menu3: false,
            menu4: false,
            preferredDistance: 20,
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
                slidesToShow: 5,
                slidesToScroll: 5,
                responsive: [
                    {
                        breakpoint: 1900,
                        settings: {
                            slidesToShow: 4,
                            slidesToScroll: 4
                        }
                    },
                    {
                        breakpoint: 1300,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3
                        }
                    },
                    {
                        breakpoint: 920,
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
                    }
                ]
            },
            media: [
                {},

                {
                    video: true
                },

                {},

                {
                    video: true
                },

                {},

                {
                    video: true
                },

                {},

                {
                    video: true
                },

                {},

                {
                    video: true
                }
            ]
        };
    },
    filters: {
        formatTime(time) {
            return moment(time, "HH:mm").format("hh:mm a");
        },
        formatDate(date) {
            return moment(date, "YYYY-MM-DD").format("DD MMM");
        }
    },
    computed: {},
    methods: {
        handleInit(event, slick) {
            slick.goTo(slick.currentSlide);
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
.service {
    &__ava {
        font-size: 0;
        .v-image__image {
            border-radius: 20px;
            overflow: hidden;
        }
        .v-badge__badge {
            width: 40px;
            height: 40px;
            line-height: 40px;
            box-shadow: 0 0 0 3px white;
        }
    }
    &__discount {
        position: relative;
        background: #18c3c8;
        color: #fff;
        @include b(768) {
            align-items: flex-end;
            justify-content: space-between;
            padding-top: 40px !important;
        }
        .discount {
            &__icon {
                display: block;
                font-size: 0;
                @include b(1023) {
                    display: none;
                }
            }
            &__title {
                font-size: 24px;
                font-weight: bold;

                @include b(1023) {
                    flex: 0 1 auto !important;
                    margin: 0 5px 0 0 !important;
                    line-height: 1.4;
                }
            }
            &__amount {
                font-size: 40px;
                font-weight: bold;
                @include b(768) {
                    line-height: 1;
                    margin: 0 0 0 20px !important;
                }
            }
            &__actions {
                @include b(768) {
                    position: absolute;
                    right: 10px;
                    top: 5px;
                    margin: 0 !important;
                }
                .v-btn,
                .btn {
                    svg {
                        transition: fill 0.15s ease-in-out;
                    }
                    &:hover {
                        svg {
                            fill: #fff !important;
                        }
                    }
                }
            }
        }
    }
    &__days {
        margin: 0 -1px !important;
        .service__day {
            padding: 0 !important;
            margin: 0 1px;
            input {
                text-indent: -9999px;
                font-size: 0;
                line-height: 0;
                width: 0;
                height: 0;
                visibility: hidden;
                opacity: 0;
                display: block;
                appearance: none;
                position: absolute;
            }
            label {
                width: 100%;
                display: block;
                height: 100%;
                font-size: 18px;
                font-weight: bold;
                padding: 20px;
                background: #e2eafd;
                color: #0e36a4;
                transition: all 0.15s ease-in-out;
                text-transform: uppercase;
                @include b(tablet) {
                    padding: 6px 3px !important;
                    font-size: 14px;
                }
                &:hover {
                    background: #7094f7;
                    color: #fff;
                }
            }
            :checked + label {
                background: #7094f7;
                color: #fff;
            }
        }
    }
}
.distance-slider {
    .vue-slider {
        background: #e2eafd;
        &-dot {
            &-handle {
                background-color: #7094f7 !important;
                box-shadow: 0 0 0 5px rgba(#7094f7, 0.3) !important;
            }
        }
        &-process {
            background-color: #7094f7 !important;
        }
    }
}
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
.question {
    color: #171a77;
}
.gallery {
    display: flex;
    flex-flow: row wrap;
    margin: 20px 0 0;
    justify-content: space-between;
    @include b(1599) {
        justify-content: space-evenly;
    }
    &__item {
        margin: 0;
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
    &.slider {
        display: block;
        .slick-track {
        }
        .slick-slide {
            margin: 0 10px;
        }
        .gallery__item {
            box-shadow: none;
            overflow: visible;
            padding: 0 0 30px 0;
            margin: 0;
            .card {
                box-shadow: 0px 15px 30px 0px rgba(10, 15, 67, 0.11);
            }
        }
    }
}
.slot {
    padding: 8px 25px;
    border-radius: 5px;
    color: #fff;
    text-align: center;
    cursor: pointer;
    @extend .raised;
    @include b(min) {
        padding: 8px 15px;
    }
    &.round {
        border-radius: 50px;
    }
    &.range {
        background: #6360f8;
    }
    &.blocked {
        background: #e47fa7;
    }
    &.open {
        background: #18c3c8;
    }
    &.del {
        background: #fff;
        color: #e47fa7;
    }
    &.add {
        background: #fff;
        color: #18c3c8;
    }
}
</style>
