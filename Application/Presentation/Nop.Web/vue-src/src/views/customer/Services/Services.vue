<template lang="pug">
.services-section.tabs-main
	v-layout.page-header(row align-center justify-space-between)
		v-flex.tab-title(grow mr-4) Services List
		v-flex(shrink)
			v-menu(offset-y left)
				v-btn(flat icon color="primary" slot="activator")
					v-icon() fas fa-ellipsis-h
				v-list
					v-list-tile
						v-list-tile-title Add Service
	v-form
		v-container(fluid px-0 py-3)
			v-layout.services__filter(row wrap align-end justify-space-between)
				v-flex.filter__criteria
					label Category
					v-select(label="" :items="filter.distance" v-model="filter.selected.category" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria
					label Service
					v-select(label="" :items="filter.service" v-model="filter.selected.service" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria
					label Work Location
					v-select(label="" :items="filter.location" v-model="filter.selected.location" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria
					label Distance Travel
					v-select(label="" :items="filter.distance" v-model="filter.selected.distance" append-icon=""  hide-details menu-props="offsetY")
				v-flex.filter__criteria(shrink)
					button.btn.custom.primary.raised(:class="{'full-width':$vuetify.breakpoint.width < 768}") View
	v-layout.services(row wrap align-start)
		v-flex.service(v-for="(service) in services" :key="service.id" :class="{'discount':service.discount}")
			.card
				v-layout(row nowrap justify-end mb-4)
					v-flex.service__discount(tag="v-layout" row wrap justify-end align-center v-if="service.discount"  mr-auto)
						v-flex(mr-auto tag="span" :hidden="$vuetify.breakpoint.xs") Discount on this service
						v-flex(ml-auto mr-0 shrink tag="span" :hidden="!$vuetify.breakpoint.xs") -
						v-flex(ml-2 mr-0 shrink tag="b") {{service.discount}}%
					v-flex.service__actions(shrink ml-3 py-1)
						v-btn.ma-0(icon flat)
							svg-icon(name="eye" size="20px" fill="#d4dffd")
						v-btn.ma-0(icon flat)
							svg-icon(name="bin" size="20px" fill="#d4dffd")
				v-layout.service__header(row wrap align-start)
					v-flex.service__ava(shrink mr-4 mb-2)
						v-img.mx-auto(:src="service.image" :width="$vuetify.breakpoint.width < 768 ? 200: 100"  aspect-ratio="1")
					v-flex.service__info(grow mb-2)
						v-layout(row wrap justify-space-between)
							router-link.service__name( shrink :to="`/customer/services/${service.id}`") {{service.name}}
							v-flex.service__projects(shrink) {{service.projects}} Projects
						v-layout(row wrap justify-space-between)
							v-flex.service__label(shrink) {{service.category}}
							v-flex.service__val(shrink) 7:00 am - 8:00 pm
						v-layout(row wrap justify-space-between)
							v-flex.service__label(shrink) Distance Travel
							v-flex.service__val(shrink) {{service.distance}}
						v-layout(row wrap justify-space-between)
							v-flex.service__label(shrink) Work Location
							v-flex.service__val(shrink) {{service.location}}
				v-layout.service__highlights(row nowrap justify-stretch mb-2)
					.service__highlight.text-xs-center
						b {{service.views}}
						span Views
					.service__highlight.text-xs-center
						b {{service.leads}}
						span Leads
					.service__highlight.text-xs-center
						b ${{service.spend}}
						span Spend
				.service__description Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.
				//- v-layout.service__providers(justify-start align-center mt-4 mb-2)
				//- 	b.mr-3 Providers
				//- 	v-avatar.service__provider.mx-1.my-0(size="30" v-for="(provider,index) in service.providers" :key="index")
				//- 		img(src="https://picsum.photos/200/300/?random")
				//- 	b.ml-3 +5
</template>
<script>
import tabStyles from "../../../components/tabsView";
export default {
    data() {
        return {
			filter:{
				selected:{
					category:{
						text:"All",
						value:'all'				
					},
					service:{
						text:"All",
						value:'all'				
					},
					location:{
						text:"All",
						value:'all'				
					},
					distance:{
						text:"All",
						value:'all'				
					}
				},
				category:[
					{
						text:"All",
						value:'all'
					},
					{
						text:"Business",
						value:'business'
					},
					{
						text:"Customer",
						value:'customer'
					},
				],
				service:[
					{
						text:"All",
						value:'all'
					},
					{
						text:"Business",
						value:'business',
						selected:true
					},
					{
						text:"Customer",
						value:'customer'
					},
				],
				distance:[
					{
						text:"All",
						value:'all'
					},
					{
						text:"Business",
						value:'business',
						selected:true
					},
					{
						text:"Customer",
						value:'customer'
					},
				],
				location:[
					{
						text:"All",
						value:'all'
					},
					{
						text:"Business",
						value:'business',
						selected:true
					},
					{
						text:"Customer",
						value:'customer'
					},
				],
			},
            services: [
                {
					id:1,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "100 km",
                    projects: 0,
                    providers: 3,
                    location: "Business",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:2,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "20 km",
                    projects: 120,
                    providers: 3,
                    location: "Business/Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:3,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "75 km",
                    projects: 238,
                    providers: 3,
                    location: "Business/Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:4,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "20 km",
                    projects: 120,
                    providers: 3,
                    location: "Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:5,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "100 km",
                    projects: 0,
                    providers: 3,
                    location: "Business",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:6,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "75 km",
                    projects: 238,
                    providers: 3,
                    location: "Business/Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:7,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "100 km",
                    projects: 0,
                    providers: 3,
                    location: "Business/Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:8,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "75 km",
                    projects: 238,
                    providers: 3,
                    location: "Customer",
                    image: "https://picsum.photos/200/300/?random"
                },
                {
					id:9,
                    name: "Service Name",
                    category: "Category Name",
                    views: 269,
                    leads: 180,
                    spend: 200,
                    distance: "20 km",
                    projects: 120,
                    providers: 3,
                    location: "Customer",
                    image: "https://picsum.photos/200/300/?random"
                }
            ]
        };
    }
};
</script>


<style lang="scss">
.services-section{
	padding: 30px 70px;
	width:100%;
	@include b(1599){
		padding:15px 15px 60px
	}
}
.services__filter{
	.filter__criteria{
		@include b(1399){
			flex: 1 0 50%!important;
		}
		@include b(767){
			flex: 0 0 100%!important;
		}

	}
}
.services {
    margin: 0 -15px !important;
    .service {
        padding: 15px 15PX!important;
		flex: 1 1 500px !important;
		@include b(tablet){
			padding: 15px 0;
		}
        .card {
            border-top: 3px solid #7094f7;
            border-radius: 0 0 20px 20px;
            padding: 0 20px 15px;
            position: relative;
			@include b(tablet){
				padding: 0 10px 15px;
			}
        }
        &.discount {
            .card {
                border-top-color: #18c3c8;
            }
        }
        &__discount {
            background: #18c3c8;
            border-radius: 0 100px 100px 0;
            padding: 8px 20px;
            left: -20px;
            position: relative;
            font-size: 18px;
            color: rgb(255, 255, 255);
            line-height: 1;
			@include b(tablet){
				left:-10px;
				max-width:50%;
			}
            span {
                white-space: normal;
                word-wrap: break-word;
				display: block;
            }
            b {
                font-weight: bold;
                display: block;
            }
        }
        &__ava {
            border-radius: 20px;
            overflow: hidden;
            font-size: 0;
            line-height: 0;
			@include b(mobile){
				margin-right: auto!important;
				margin-left: auto!important;
			}
            & * {
                display: block;
            }
		}
		&__info{
			@include b(mobile){
				flex-basis:100%
			}
		}
        &__label {
            font-size: 16px;
            font-weight: 300;
            margin-right: 20px;
        }
        &__val {
            font-size: 16px;
            font-weight: bold;
            font-style: italic;
        }
        &__name {
            font-size: 24px;
            font-weight: bold;
            margin-right: 20px;
        }
        &__projects {
            font-size: 24px;
            font-weight: bold;
            color: #18c3c8;
        }
        &__highlights {
			margin-right: -10px;
			margin-left: -10px;
        }
        &__highlight {
            border: 1px solid #d2d2d2;
            line-height: 1;
            font-size: 16px;
			font-weight: 300;
			border-radius: 6px;
			margin:5px 10px;
			padding:5px 10px;
            b {
                font-size: 18px;
				font-weight: bold;
				display: inline-block;
			}
			b,span{
			padding:5px 5px;
			}
		}
		&__providers{
		}
    }
}
</style>
