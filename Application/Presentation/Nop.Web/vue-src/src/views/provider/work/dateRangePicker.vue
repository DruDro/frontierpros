<template lang="pug">
	v-layout(justify-space-between row wrap align-center style="margin-left:-1.5em; margin-right:-1.5em;")
		v-flex(ma-4 style="flex:0 1 320px")
			v-layout(v-if="mode == 'Day' || mode == 'Month'" justify-space-between align-center row nowrap)
				v-flex(shrink)
					v-btn.btn.custom.primary(icon @click="prevDate")
						v-icon chevron_left
				v-flex(shrink ml-3 mr-auto)
					.tab-title(style="line-height:1")
						span() {{dateTitle.month}}
						span(v-if="mode == 'Day'") &nbsp;{{dateTitle.day}}
					.body-2.primary--text.text--lighten-1 {{dateTitle.year}}
				v-flex(shrink ml-3)
					v-btn.btn.custom.primary(icon @click="nextDate")
						v-icon chevron_right
				v-flex( shrink ml-2)
					v-menu(offset-y)
						template(v-slot:activator="{on}")
							v-btn(v-on="on" icon flat)
								v-icon(color="primary") date_range
						v-date-picker(no-title :type="mode == 'Month' ? 'month':'date'" v-model="date" )
			.tab-title(v-if="mode == 'All Time'") Aug 2017 - Nov 2018
		v-flex.tabs(ma-4 shrink)
			v-layout(row)
				v-flex(v-for="(tab,index) in modes" :key="index" :xs12="$vuetify.breakpoint.smAndDown")
					button.btn.custom.full-width( @click="mode = tab" :class="{active:mode == tab}") {{ tab }}
</template>

<script>
import moment from "moment";
export default {
    props: [],
    data() {
        return {
            dateTitle: {
                year: moment(new Date()).format("YYYY"),
                month: moment(new Date()).format("MMMM"),
                day: moment(new Date()).format("D")
            },
            date: new Date().toJSON(),
            mode: "Day",
            modes: ["Day", "Month", "All Time"]
        };
    },
    watch: {
        mode: function(val) {
            this.$emit("change-mode", val);
        },
        date: function(val) {
            this.setDateTitle();
            this.$emit("change-date", val);
        }
    },
    computed: {},
    methods: {
        nextDate() {
            this.date =
                this.mode == "Day"
                    ? moment(this.date)
                          .add(1, "days")
                          .format("YYYY-MM-DD")
                    : moment(this.date)
                          .add(1, "months")
                          .format("YYYY-MM");
        },
        prevDate() {
            this.date =
                this.mode == "Day"
                    ? moment(this.date)
                          .subtract(1, "days")
                          .format("YYYY-MM-DD")
                    : moment(this.date)
                          .subtract(1, "months")
                          .format("YYYY-MM");
        },
        setDateTitle() {
            this.dateTitle = moment(this.date).format(
                this.mode == "Day" ? "MMMM D" : "MMMM"
            );
            switch (this.mode) {
                case "Day":
                    this.dateTitle = {
                        year: moment(this.date).format("YYYY"),
                        month: moment(this.date).format("MMMM"),
                        day: moment(this.date).format("D")
                    };
                    break;
                case "Month":
                    this.dateTitle = {
                        year: moment(this.date).format("YYYY"),
                        month: moment(this.date).format("MMMM")
                    };
            }
        }
    },
    mounted() {}
};
</script>

<style lang="scss">
</style>