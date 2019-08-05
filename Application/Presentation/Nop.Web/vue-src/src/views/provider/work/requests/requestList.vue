<template lang="pug">
.work-section
	v-form
		v-container(fluid px-0 py-3 grid-list-xl)
			v-layout.services__filter(row wrap  justify-space-between)
				v-flex.filter__criteria(md4 sm6 xs12)
					label
						b Job ID
					v-select(label="" :items="filter.jobId" v-model="filter.selected.jobId" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(md4 sm6 xs12)
					label
						b Job Name
					v-select(label="" :items="filter.jobName" v-model="filter.selected.jobName" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(md4 sm6 xs12)
					label
						b Customer
					v-select(label="" :items="filter.customer" v-model="filter.selected.customer" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(md4 sm6 xs12)
					label
						b Category Name
					v-select(label="" :items="filter.categoryName" v-model="filter.selected.categoryName" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(md4 sm6 xs12)
					label
						b Service Name
					v-select(label="" :items="filter.serviceName" v-model="filter.selected.serviceName" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(lg2 md4 sm6 xs12 shrink)
					label
						b Location
					v-select(label="" :items="filter.location" v-model="filter.selected.location" append-icon="" hide-details menu-props="offsetY")
				v-flex.filter__criteria(lg2 md4 sm6 xs12 shrink)
					label
						b Work Distance
					v-select(label="" :items="filter.distance" v-model="filter.selected.distance" append-icon="" hide-details menu-props="offsetY")
	date-range-picker(@change-date="onChangeDate" @change-mode="onChangeMode" )
</template>
<script>
import dateRangePicker from "../dateRangePicker.vue";
import tabStyles from "../../../../components/tabsView";
import moment from 'moment';

import { APIServices } from "../../../../api/api-services";

export default {
    components: {
        "date-range-picker": dateRangePicker
    },
    props: {
        pageTitle: {
            type: String
        }
    },
    data() {
        return {
			mode:'Day',
			date:null,
            filter: {
                selected: {
                    jobId: {
                        text: "All",
                        value: "all"
                    },
                    jobName: {
                        text: "All",
                        value: "all"
                    },
                    customer: {
                        text: "All",
                        value: "all"
                    },
                    categoryName: {
                        text: "All",
                        value: "all"
                    },
                    serviceName: {
                        text: "All",
                        value: "all"
                    },
                    location: {
                        text: "All",
                        value: "all"
                    },
                    distance: {
                        text: "All",
                        value: "all"
                    }
                },
                jobId: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                jobName: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                customer: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                categoryName: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                serviceName: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                location: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ],
                distance: [
                    {
                        text: "All",
                        value: "all"
                    },
                    {
                        text: "1",
                        value: "1"
                    },
                    {
                        text: "2",
                        value: "2"
                    }
                ]
            }
        };
    },
    methods: {
		onChangeDate(val){
			this.date = val;
		},
		onChangeMode(val){
			this.mode = val;
		}
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>


<style lang="scss">
.work-section {
    padding: 30px 0;
    width: 100%;
    @include b(1599) {
        padding: 15px 15px 60px;
    }
}
.services__filter {
    .filter__criteria {
        @include b(1399) {
            flex: 1 0 50% !important;
        }
        @include b(767) {
            flex: 0 0 100% !important;
        }
    }
}
.services {
    margin: 0 -15px !important;
    .service {
        padding: 15px 15px !important;
        flex: 1 1 500px !important;
        @include b(tablet) {
            padding: 15px 0;
        }
        .card {
            border-top: 3px solid #7094f7;
            border-radius: 0 0 20px 20px;
            padding: 0 20px 15px;
            position: relative;
            @include b(tablet) {
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
            @include b(tablet) {
                left: -10px;
                max-width: 50%;
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
            @include b(mobile) {
                margin-right: auto !important;
                margin-left: auto !important;
            }
            & * {
                display: block;
            }
        }
        &__info {
            @include b(mobile) {
                flex-basis: 100%;
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
            margin: 5px 10px;
            padding: 5px 10px;
            b {
                font-size: 18px;
                font-weight: bold;
                display: inline-block;
            }
            b,
            span {
                padding: 5px 5px;
            }
        }
        &__providers {
        }
    }
}
</style>
