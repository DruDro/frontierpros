(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-52f2c323"],{2677:function(t,e,a){"use strict";a.d(e,"a",function(){return c});var i=a("8654"),s=a("a844"),r=a("7cf7"),n=a("ab6d"),l=a("d9bd"),c={functional:!0,$_wrapperFor:i["a"],props:{textarea:Boolean,multiLine:Boolean},render:function(t,e){var a=e.props,o=e.data,u=e.slots,d=e.parent;Object(n["a"])(o);var v=Object(r["a"])(u(),t);return a.textarea&&Object(l["d"])("<v-text-field textarea>","<v-textarea outline>",c,d),a.multiLine&&Object(l["d"])("<v-text-field multi-line>","<v-textarea>",c,d),a.textarea||a.multiLine?(o.attrs.outline=a.textarea,t(s["a"],o,v)):t(i["a"],o,v)}}},"7cf7":function(t,e,a){"use strict";function i(t,e){var a=[];for(var i in t)t.hasOwnProperty(i)&&a.push(e("template",{slot:i},t[i]));return a}a.d(e,"a",function(){return i})},"7e63":function(t,e,a){},a844:function(t,e,a){"use strict";a("7e63");var i=a("8654"),s=a("d9bd"),r=Object.assign||function(t){for(var e=1;e<arguments.length;e++){var a=arguments[e];for(var i in a)Object.prototype.hasOwnProperty.call(a,i)&&(t[i]=a[i])}return t};e["a"]={name:"v-textarea",extends:i["a"],props:{autoGrow:Boolean,noResize:Boolean,outline:Boolean,rowHeight:{type:[Number,String],default:24,validator:function(t){return!isNaN(parseFloat(t))}},rows:{type:[Number,String],default:5,validator:function(t){return!isNaN(parseInt(t,10))}}},computed:{classes:function(){return r({"v-textarea":!0,"v-textarea--auto-grow":this.autoGrow,"v-textarea--no-resize":this.noResizeHandle},i["a"].options.computed.classes.call(this,null))},dynamicHeight:function(){return this.autoGrow?this.inputHeight:"auto"},isEnclosed:function(){return this.textarea||i["a"].options.computed.isEnclosed.call(this)},noResizeHandle:function(){return this.noResize||this.autoGrow}},watch:{lazyValue:function(){!this.internalChange&&this.autoGrow&&this.$nextTick(this.calculateInputHeight)}},mounted:function(){var t=this;setTimeout(function(){t.autoGrow&&t.calculateInputHeight()},0),this.autoGrow&&this.noResize&&Object(s["b"])('"no-resize" is now implied when using "auto-grow", and can be removed',this)},methods:{calculateInputHeight:function(){var t=this.$refs.input;if(t){t.style.height=0;var e=t.scrollHeight,a=parseInt(this.rows,10)*parseFloat(this.rowHeight);t.style.height=Math.max(a,e)+"px"}},genInput:function(){var t=i["a"].options.methods.genInput.call(this);return t.tag="textarea",delete t.data.attrs.type,t.data.attrs.rows=this.rows,t},onInput:function(t){i["a"].options.methods.onInput.call(this,t),this.autoGrow&&this.calculateInputHeight()},onKeyDown:function(t){this.isFocused&&13===t.keyCode&&t.stopPropagation(),this.internalChange=!0,this.$emit("keydown",t)}}}},aa29:function(t,e,a){"use strict";a.r(e);var i=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"tab-content"},[a("h3",[t._v("What Should The Customer Know About Your Pricing?")]),a("v-container",{attrs:{fluid:"","pa-0":"","ma-0":"","grid-list-xl":""}},[a("v-layout",{attrs:{row:"",wrap:"","mt-4":""}},[a("v-layout",{staticClass:"flex",attrs:{shrink:"","ma-0":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"prepayments",checked:t.prepayments},nativeOn:{click:function(e){t.prepayments=!t.prepayments}}}),a("label",{staticClass:"font-weight-bold shrink",attrs:{for:"prepayments"}},[t._v("Prepayments")])],1),a("v-layout",{staticClass:"flex",attrs:{shrink:"","ma-0":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"giftCards",checked:t.giftCards},nativeOn:{click:function(e){t.giftCards=!t.giftCards}}}),a("label",{staticClass:"font-weight-bold shrink",attrs:{for:"giftCards"}},[t._v("Accepts Gift Cards")])],1),a("v-layout",{staticClass:"flex",attrs:{shrink:"","ma-0":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"fees",checked:t.fees},nativeOn:{click:function(e){t.fees=!t.fees}}}),a("label",{staticClass:"font-weight-bold shrink",attrs:{for:"fees"}},[t._v("Fees")])],1),a("v-layout",{staticClass:"flex",attrs:{shrink:"","ma-0":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"firstTimeCustomerDiscount",checked:t.firstTimeCustomerDiscount},nativeOn:{click:function(e){t.firstTimeCustomerDiscount=!t.firstTimeCustomerDiscount}}}),a("label",{staticClass:"font-weight-bold shrink",attrs:{for:"firstTimeCustomerDiscount"}},[t._v("First Time Customer Discount")])],1),a("v-layout",{staticClass:"flex",attrs:{shrink:"","ma-0":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"discountedHourlyPrice",checked:t.discountedHourlyPrice},nativeOn:{click:function(e){t.discountedHourlyPrice=!t.discountedHourlyPrice}}}),a("label",{staticClass:"font-weight-bold shrink",attrs:{for:"discountedHourlyPrice"}},[t._v("Discounted Hourly Price")])],1)],1)],1),a("card",{staticClass:"mt-4"},[a("label",{staticClass:"font-weight-bold"},[t._v("Payment Details")]),a("v-textarea",{staticClass:"custom--round",attrs:{rows:"8",outline:"",value:"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. \nExcepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat "}})],1),a("card",[a("h3",[t._v("Price")]),a("v-container",{attrs:{fluid:"","pa-0":"","ma-0":"","grid-list-xl":""}},[a("v-layout",{attrs:{"pa-0":"","my-0":"",wrap:""}},[a("v-flex",{attrs:{md6:"",xs12:""}},[a("v-layout",{attrs:{"my-0":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink",staticStyle:{color:"#1d2284"}},[t._v("Enter Your Base Price")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.basePriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.basePriceActive},nativeOn:{click:function(e){t.basePriceActive=!t.basePriceActive}}})],1)],1),a("p",{staticClass:"hint"},[t._v("Your base price for wedding customer includes consultation, music, speakers, microphones, and setup & breakdown.")]),a("label",{staticClass:"font-weight-bold mt-4 d-block"},[t._v(t._s(t.discountedHourlyPrice?"Discounted":"Flat")+" Hourly Price")]),a("v-layout",{attrs:{shrink:"","ma-0":"","mt-2":"","align-center":""}},[a("checkbox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"weekendPricing",checked:t.weekendPricing},nativeOn:{click:function(e){t.weekendPricing=!t.weekendPricing}}}),a("label",{staticClass:"font-weight-light shrink",attrs:{for:"weekendPricing"}},[t._v("Enter Different Weekend Pricing")])],1),a("div",{staticClass:"mt-4",class:{"grey--text text--lighten-1":!t.weekendPricing}},[a("label",{staticClass:"font-weight-bold d-block"},[t._v("Choose Weekend Schedule")]),a("v-layout",{attrs:{"my-0":"","align-center":"",wrap:"","justify-start":""}},[a("v-layout",{staticClass:"flex",attrs:{"ma-0":"",nowrap:"","align-center":""}},[a("radiobox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"SatSun",name:"weekend",disabled:!t.weekendPricing}}),a("label",{staticClass:"font-weight-light shrink",attrs:{for:"SatSun"}},[t._v("SAT-SUN")])],1),a("v-layout",{staticClass:"flex",attrs:{sm7:"","ma-0":"",nowrap:"","align-center":""}},[a("radiobox",{staticClass:"sm shrink flex mr-2 pa-0",attrs:{id:"FriSat",name:"weekend",disabled:!t.weekendPricing}}),a("label",{staticClass:"font-weight-light shrink",attrs:{for:"FriSat"}},[t._v("FRI-SAT\t\t\t\t\t")])],1)],1)],1),a("v-layout",{attrs:{"my-0":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",{staticClass:"font-weight-bold"},[t._v("% of Deposits Required")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"0 %"}})],1)],1),a("label",{staticClass:"font-weight-bold mt-5 d-block"},[t._v("JOB")]),a("v-layout",{attrs:{"my-0":"","align-end":""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",[t._v("1h")])]),a("v-layout",{staticClass:"flex",attrs:{sm10:"","align-end":"","py-0":"","my-0":""}},[a("v-flex",{attrs:{shrink:"","py-0":""}},[a("label",{staticClass:"text-no-wrap",staticStyle:{color:"#7094f7"}},[t._v("Rec. $40")])]),a("v-flex",{attrs:{"py-0":""}},[a("v-text-field",{attrs:{"hide-details":"",label:"",height:"30",value:"$40"}})],1)],1)],1),t.prepayments?a("div",{staticClass:"mt-5"},[a("v-layout",{attrs:{"my-0":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink",staticStyle:{color:"#1d2284"}},[t._v("Prepayment")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.prepaymentPriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.prepaymentPriceActive},nativeOn:{click:function(e){t.prepaymentPriceActive=!t.prepaymentPriceActive}}})],1)],1),a("p",{staticClass:"hint"},[t._v("The client may send part of the cost of the service with prepayment.")]),a("v-layout",{attrs:{"my-0":"","mt-2":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",[t._v("Prepayment Cost")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"$0"}})],1)],1)],1):t._e()],1),a("v-flex",{attrs:{md6:"",xs12:""}},[t.giftCards?a("div",{staticClass:"mb-5"},[a("v-layout",{attrs:{"my-0":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink",staticStyle:{color:"#1d2284"}},[t._v("Accepts Gift Cards")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.giftCardsPriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.giftCardsPriceActive},nativeOn:{click:function(e){t.giftCardsPriceActive=!t.giftCardsPriceActive}}})],1)],1),a("p",{staticClass:"hint"},[t._v("A customer can send a part of the service cost with a gift card.")]),a("v-layout",{attrs:{"my-0":"","mt-2":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",[t._v("% payment by gift card")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"0 %"}})],1)],1)],1):t._e(),t.firstTimeCustomerDiscount?a("div",{staticClass:"mb-5"},[a("v-layout",{attrs:{"my-0":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink",staticStyle:{color:"#1d2284"}},[t._v("Discount for First-Time Customer")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.firstTimeCustomerPriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.firstTimeCustomerPriceActive},nativeOn:{click:function(e){t.firstTimeCustomerPriceActive=!t.firstTimeCustomerPriceActive}}})],1)],1),a("p",{staticClass:"hint"},[t._v("Let customers know about all discounts")]),a("v-layout",{attrs:{"my-0":"","mt-2":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",[t._v("First-time customer")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"0"}})],1)],1)],1):t._e(),a("h4",{staticClass:"mt-3 mb-1",staticStyle:{color:"#1d2284"}},[t._v("Enter Add-On Price")]),a("p",{staticClass:"hint"},[t._v("Your base price for wedding customer includes consultation, music, speakers, microphones, and setup & breakdown.")]),a("v-layout",{attrs:{"my-0":"","mt-2":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink"},[t._v("Add-On Service")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.addOnServicePriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.addOnServicePriceActive},nativeOn:{click:function(e){t.addOnServicePriceActive=!t.addOnServicePriceActive}}})],1)],1),a("v-layout",{attrs:{"my-0":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",{staticClass:"font-weight-bold"},[t._v("% of Deposits Required")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"100 %"}})],1)],1),a("v-layout",{attrs:{"my-0":"","align-end":"","mt-3":"","justify-start":"",wrap:t.$vuetify.breakpoint.xs}},[a("v-flex",{attrs:{"py-0":"",grow:""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"New Add-Ons Service","read-only":""}})],1),a("v-flex",{attrs:{sm7:"","py-0":"",xs12:"","mt-2":t.$vuetify.breakpoint.xs}},[a("v-btn",{staticClass:"btn transparent custom capitalize",class:{"full-width":t.$vuetify.breakpoint.xs},attrs:{flat:"",color:"primary"}},[a("svg-icon",{staticClass:"mr-2",attrs:{size:"20px",name:"plus"}}),t._v("Add New")],1)],1)],1),a("v-layout",{attrs:{"my-0":"","mt-4":"","pa-0":"",row:"",wrap:"","justify-space-between":"","align-center":""}},[a("h4",{staticClass:"flex shrink"},[t._v("Add-On Product")]),a("v-layout",{staticClass:"flex setting",attrs:{shrink:"","ma-0":"","align-center":"",nowrap:""}},[a("label",{staticClass:"mr-4"},[t._v("Price "+t._s(t.addOnProductPriceActive?"Active":"Inactive"))]),a("switcher",{staticClass:"green-pink",attrs:{checked:t.addOnProductPriceActive},nativeOn:{click:function(e){t.addOnProductPriceActive=!t.addOnProductPriceActive}}})],1)],1),a("v-layout",{attrs:{"my-0":"","align-end":"","justify-start":"",nowrap:""}},[a("v-flex",{attrs:{"py-0":""}},[a("label",{staticClass:"font-weight-bold"},[t._v("% of Deposits Required")])]),a("v-flex",{attrs:{sm7:"","py-0":""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"100 %"}})],1)],1),a("v-layout",{attrs:{"my-0":"","align-end":"","mt-3":"",wrap:t.$vuetify.breakpoint.xs,"justify-start":""}},[a("v-flex",{attrs:{"py-0":"",grow:""}},[a("v-text-field",{attrs:{height:"30",label:"","hide-details":"",value:"New Add-Ons Product","read-only":""}})],1),a("v-flex",{attrs:{sm7:"","py-0":"",xs12:"","mt-2":t.$vuetify.breakpoint.xs}},[a("v-btn",{staticClass:"btn transparent custom capitalize",class:{"full-width":t.$vuetify.breakpoint.xs},attrs:{flat:"",color:"primary"}},[a("svg-icon",{staticClass:"mr-2",attrs:{size:"20px",name:"plus"}}),t._v("Add New")],1)],1)],1)],1)],1)],1)],1)],1)},s=[],r=(a("cadf"),a("551c"),a("097d"),{props:{pageTitle:{type:String}},data:function(){return{prepayments:!0,prepaymentPriceActive:!1,giftCards:!0,giftCardsPriceActive:!1,fees:!1,firstTimeCustomerDiscount:!0,firstTimeCustomerPriceActive:!1,discountedHourlyPrice:!1,basePriceActive:!1,addOnServicePriceActive:!1,addOnProductPriceActive:!1,weekendPricing:!1}},mounted:function(){this.$emit("passTitle",this.pageTitle)}}),n=r,l=a("2877"),c=a("6544"),o=a.n(c),u=a("8336"),d=a("a523"),v=a("0e8f"),p=a("a722"),m=a("2677"),f=a("a844"),h=Object(l["a"])(n,i,s,!1,null,null,null);h.options.__file="ServicePrice.vue";e["default"]=h.exports;o()(h,{VBtn:u["a"],VContainer:d["a"],VFlex:v["a"],VLayout:p["a"],VTextField:m["a"],VTextarea:f["a"]})},ab6d:function(t,e,a){"use strict";function i(t){if(t.model&&t.on&&t.on.input)if(Array.isArray(t.on.input)){var e=t.on.input.indexOf(t.model.callback);e>-1&&t.on.input.splice(e,1)}else delete t.on.input}a.d(e,"a",function(){return i})}}]);
//# sourceMappingURL=chunk-52f2c323.js.map