(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-12f94af0"],{"1c63":function(t,e,s){},"26e5":function(t,e,s){},"326c":function(t,e,s){"use strict";s.r(e);var i=function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",{staticClass:"services-section tabs-main"},[s("v-layout",{staticClass:"page-header",attrs:{row:"","align-center":"","justify-space-between":""}},[s("v-flex",{staticClass:"tab-title",attrs:{grow:"","mr-4":""}},[t._v("Services List")]),s("v-flex",{attrs:{shrink:""}},[s("v-menu",{attrs:{"offset-y":"",left:""}},[s("v-btn",{attrs:{slot:"activator",flat:"",icon:"",color:"primary"},slot:"activator"},[s("v-icon",[t._v("fas fa-ellipsis-h")])],1),s("v-list",[s("v-list-tile",[s("v-list-tile-title",[t._v("Add Service")])],1)],1)],1)],1)],1),s("v-form",[s("v-container",{attrs:{fluid:"","px-0":"","py-3":""}},[s("v-layout",{staticClass:"services__filter",attrs:{row:"",wrap:"","align-end":"","justify-space-between":""}},[s("v-flex",{staticClass:"filter__criteria"},[s("label",[t._v("Category")]),s("v-select",{attrs:{label:"",items:t.filter.distance,"append-icon":"","hide-details":"","menu-props":"offsetY"},model:{value:t.filter.selected.category,callback:function(e){t.$set(t.filter.selected,"category",e)},expression:"filter.selected.category"}})],1),s("v-flex",{staticClass:"filter__criteria"},[s("label",[t._v("Service")]),s("v-select",{attrs:{label:"",items:t.filter.service,"append-icon":"","hide-details":"","menu-props":"offsetY"},model:{value:t.filter.selected.service,callback:function(e){t.$set(t.filter.selected,"service",e)},expression:"filter.selected.service"}})],1),s("v-flex",{staticClass:"filter__criteria"},[s("label",[t._v("Work Location")]),s("v-select",{attrs:{label:"",items:t.filter.location,"append-icon":"","hide-details":"","menu-props":"offsetY"},model:{value:t.filter.selected.location,callback:function(e){t.$set(t.filter.selected,"location",e)},expression:"filter.selected.location"}})],1),s("v-flex",{staticClass:"filter__criteria"},[s("label",[t._v("Distance Travel")]),s("v-select",{attrs:{label:"",items:t.filter.distance,"append-icon":"","hide-details":"","menu-props":"offsetY"},model:{value:t.filter.selected.distance,callback:function(e){t.$set(t.filter.selected,"distance",e)},expression:"filter.selected.distance"}})],1),s("v-flex",{staticClass:"filter__criteria",attrs:{shrink:""}},[s("button",{staticClass:"btn custom primary raised",class:{"full-width":t.$vuetify.breakpoint.width<768}},[t._v("View")])])],1)],1)],1),s("v-layout",{staticClass:"services",attrs:{row:"",wrap:"","align-start":""}},t._l(t.services,function(e){return s("v-flex",{key:e.id,staticClass:"service",class:{discount:e.discount}},[s("div",{staticClass:"card"},[s("v-layout",{attrs:{row:"",nowrap:"","justify-end":"","mb-4":""}},[e.discount?s("v-flex",{staticClass:"service__discount",attrs:{tag:"v-layout",row:"",wrap:"","justify-end":"","align-center":"","mr-auto":""}},[s("v-flex",{attrs:{"mr-auto":"",tag:"span",hidden:t.$vuetify.breakpoint.xs}},[t._v("Discount on this service")]),s("v-flex",{attrs:{"ml-auto":"","mr-0":"",shrink:"",tag:"span",hidden:!t.$vuetify.breakpoint.xs}},[t._v("-")]),s("v-flex",{attrs:{"ml-2":"","mr-0":"",shrink:"",tag:"b"}},[t._v(t._s(e.discount)+"%")])],1):t._e(),s("v-flex",{staticClass:"service__actions",attrs:{shrink:"","ml-3":"","py-1":""}},[s("v-btn",{staticClass:"ma-0",attrs:{icon:"",flat:""}},[s("svg-icon",{attrs:{name:"eye",size:"20px",fill:"#d4dffd"}})],1),s("v-btn",{staticClass:"ma-0",attrs:{icon:"",flat:""}},[s("svg-icon",{attrs:{name:"bin",size:"20px",fill:"#d4dffd"}})],1)],1)],1),s("v-layout",{staticClass:"service__header",attrs:{row:"",wrap:"","align-start":""}},[s("v-flex",{staticClass:"service__ava",attrs:{shrink:"","mr-4":"","mb-2":""}},[s("v-img",{staticClass:"mx-auto",attrs:{src:e.image,width:t.$vuetify.breakpoint.width<768?200:100,"aspect-ratio":"1"}})],1),s("v-flex",{staticClass:"service__info",attrs:{grow:"","mb-2":""}},[s("v-layout",{attrs:{row:"",wrap:"","justify-space-between":""}},[s("router-link",{staticClass:"service__name",attrs:{shrink:"",to:"/services/"+e.id}},[t._v(t._s(e.name))]),s("v-flex",{staticClass:"service__projects",attrs:{shrink:""}},[t._v(t._s(e.projects)+" Projects")])],1),s("v-layout",{attrs:{row:"",wrap:"","justify-space-between":""}},[s("v-flex",{staticClass:"service__label",attrs:{shrink:""}},[t._v(t._s(e.category))]),s("v-flex",{staticClass:"service__val",attrs:{shrink:""}},[t._v("7:00 am - 8:00 pm")])],1),s("v-layout",{attrs:{row:"",wrap:"","justify-space-between":""}},[s("v-flex",{staticClass:"service__label",attrs:{shrink:""}},[t._v("Distance Travel")]),s("v-flex",{staticClass:"service__val",attrs:{shrink:""}},[t._v(t._s(e.distance))])],1),s("v-layout",{attrs:{row:"",wrap:"","justify-space-between":""}},[s("v-flex",{staticClass:"service__label",attrs:{shrink:""}},[t._v("Work Location")]),s("v-flex",{staticClass:"service__val",attrs:{shrink:""}},[t._v(t._s(e.location))])],1)],1)],1),s("v-layout",{staticClass:"service__highlights",attrs:{row:"",nowrap:"","justify-stretch":"","mb-2":""}},[s("div",{staticClass:"service__highlight text-xs-center"},[s("b",[t._v(t._s(e.views))]),s("span",[t._v("Views")])]),s("div",{staticClass:"service__highlight text-xs-center"},[s("b",[t._v(t._s(e.leads))]),s("span",[t._v("Leads")])]),s("div",{staticClass:"service__highlight text-xs-center"},[s("b",[t._v("$"+t._s(e.spend))]),s("span",[t._v("Spend")])])]),s("div",{staticClass:"service__description"},[t._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.")]),s("v-layout",{staticClass:"service__providers",attrs:{"justify-start":"","align-center":"","mt-4":"","mb-2":""}},[s("b",{staticClass:"mr-3"},[t._v("Providers")]),t._l(e.providers,function(t,e){return s("v-avatar",{key:e,staticClass:"service__provider mx-1 my-0",attrs:{size:"30"}},[s("img",{attrs:{src:"https://picsum.photos/200/300/?random"}})])}),s("b",{staticClass:"ml-3"},[t._v("+5")])],2)],1)])}),1)],1)},a=[],r=(s("9e65"),{data:function(){return{filter:{selected:{category:{text:"All",value:"all"},service:{text:"All",value:"all"},location:{text:"All",value:"all"},distance:{text:"All",value:"all"}},category:[{text:"All",value:"all"},{text:"Business",value:"business"},{text:"Customer",value:"customer"}],service:[{text:"All",value:"all"},{text:"Business",value:"business",selected:!0},{text:"Customer",value:"customer"}],distance:[{text:"All",value:"all"},{text:"Business",value:"business",selected:!0},{text:"Customer",value:"customer"}],location:[{text:"All",value:"all"},{text:"Business",value:"business",selected:!0},{text:"Customer",value:"customer"}]},services:[{id:1,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"100 km",projects:0,providers:3,location:"Business",image:"https://picsum.photos/200/300/?random"},{id:2,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"20 km",projects:120,providers:3,discount:20,location:"Business/Customer",image:"https://picsum.photos/200/300/?random"},{id:3,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"75 km",projects:238,providers:3,location:"Business/Customer",image:"https://picsum.photos/200/300/?random"},{id:4,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"20 km",projects:120,providers:3,discount:20,location:"Customer",image:"https://picsum.photos/200/300/?random"},{id:5,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"100 km",projects:0,providers:3,location:"Business",image:"https://picsum.photos/200/300/?random"},{id:6,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"75 km",projects:238,providers:3,location:"Business/Customer",image:"https://picsum.photos/200/300/?random"},{id:7,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"100 km",projects:0,providers:3,location:"Business/Customer",image:"https://picsum.photos/200/300/?random"},{id:8,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"75 km",projects:238,providers:3,location:"Customer",image:"https://picsum.photos/200/300/?random"},{id:9,name:"Service Name",category:"Category Name",views:269,leads:180,spend:200,distance:"20 km",projects:120,providers:3,discount:20,location:"Customer",image:"https://picsum.photos/200/300/?random"}]}}}),l=r,n=(s("b6f4"),s("2877")),o=s("6544"),c=s.n(o),u=s("8212"),v=s("8336"),d=s("a523"),m=s("0e8f"),p=s("4bd4"),f=s("132d"),h=s("adda"),_=s("a722"),g=s("8860"),b=s("ba95"),y=s("5d23"),w=s("e449"),x=s("b56d"),C=Object(n["a"])(l,i,a,!1,null,null,null);C.options.__file="Services.vue";e["default"]=C.exports;c()(C,{VAvatar:u["a"],VBtn:v["a"],VContainer:d["a"],VFlex:m["a"],VForm:p["a"],VIcon:f["a"],VImg:h["a"],VLayout:_["a"],VList:g["a"],VListTile:b["a"],VListTileTitle:y["b"],VMenu:w["a"],VSelect:x["a"]})},"4bd4":function(t,e,s){"use strict";s("26e5");var i=s("94ab");e["a"]={name:"v-form",mixins:[Object(i["b"])("form")],inheritAttrs:!1,props:{value:Boolean,lazyValidation:Boolean},data:function(){return{inputs:[],watchers:[],errorBag:{}}},watch:{errorBag:{handler:function(){var t=Object.values(this.errorBag).includes(!0);this.$emit("input",!t)},deep:!0,immediate:!0}},methods:{watchInput:function(t){var e=this,s=function(t){return t.$watch("hasError",function(s){e.$set(e.errorBag,t._uid,s)},{immediate:!0})},i={_uid:t._uid,valid:void 0,shouldValidate:void 0};return this.lazyValidation?i.shouldValidate=t.$watch("shouldValidate",function(a){a&&(e.errorBag.hasOwnProperty(t._uid)||(i.valid=s(t)))}):i.valid=s(t),i},validate:function(){var t=this.inputs.filter(function(t){return!t.validate(!0)}).length;return!t},reset:function(){for(var t=this,e=this.inputs.length;e--;)this.inputs[e].reset();this.lazyValidation&&setTimeout(function(){t.errorBag={}},0)},resetValidation:function(){for(var t=this,e=this.inputs.length;e--;)this.inputs[e].resetValidation();this.lazyValidation&&setTimeout(function(){t.errorBag={}},0)},register:function(t){var e=this.watchInput(t);this.inputs.push(t),this.watchers.push(e)},unregister:function(t){var e=this.inputs.find(function(e){return e._uid===t._uid});if(e){var s=this.watchers.find(function(t){return t._uid===e._uid});s.valid&&s.valid(),s.shouldValidate&&s.shouldValidate(),this.watchers=this.watchers.filter(function(t){return t._uid!==e._uid}),this.inputs=this.inputs.filter(function(t){return t._uid!==e._uid}),this.$delete(this.errorBag,e._uid)}}},render:function(t){var e=this;return t("form",{staticClass:"v-form",attrs:Object.assign({novalidate:!0},this.$attrs),on:{submit:function(t){return e.$emit("submit",t)}}},this.$slots.default)}}},"9e65":function(t,e,s){"use strict";s("e7a2");var i,a,r=s("2877"),l={},n=Object(r["a"])(l,i,a,!1,null,null,null);n.options.__file="tabsView.vue";n.exports},b6f4:function(t,e,s){"use strict";var i=s("1c63"),a=s.n(i);a.a},d645:function(t,e,s){},e7a2:function(t,e,s){"use strict";var i=s("d645"),a=s.n(i);a.a}}]);
//# sourceMappingURL=chunk-12f94af0.js.map