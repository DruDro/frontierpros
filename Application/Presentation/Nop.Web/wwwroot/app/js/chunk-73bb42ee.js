(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-73bb42ee"],{ca6d:function(i,t,s){"use strict";var e=s("f430"),a=s.n(e);a.a},eb84:function(i,t,s){"use strict";s.r(t);var e=function(){var i=this,t=i.$createElement,s=i._self._c||t;return s("div",{directives:[{name:"resize",rawName:"v-resize",value:i.onResize,expression:"onResize"}],staticClass:"tab-content"},[s("v-layout",{attrs:{row:"",wrap:"","align-center":"","justify-space-between":""}},[s("v-flex",{class:{"pr-0 pb-4":i.$vuetify.breakpoint.xs,"pr-4":i.$vuetify.breakpoint.smAndUp},attrs:{xs12:"",sm8:"",xl10:""}},[s("b",[i._v("Photo & Video")]),s("p",[i._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit")])]),s("v-flex",{attrs:{xs12:"",sm4:"",xl2:""}},[s("button",{staticClass:"btn custom large primary full-width"},[i._v("Add New")])])],1),s("div",{staticClass:"profile-gallery"},[s("v-layout",{attrs:{"justify-space-between":"","align-center":"",wrap:""}},[s("v-flex",{attrs:{shrink:""}},[s("b",[i._v("13 Photos/Videos")])]),s("v-flex",{attrs:{shrink:""}},[s("a",{staticClass:"expand-gallery font-weight-bold",attrs:{hidden:i.vw<1024},on:{click:function(t){return i.toggleGallery()}}},[i._v(i._s(i.galleryExpanded?"Show Less":"Show All"))])])],1),i.vw>=1024?s("div",{staticClass:"gallery"},i._l(i.media,function(t,e){return s("div",{staticClass:"gallery__item"},[s("div",{staticClass:"card"},[s("div",{staticClass:"bg"},[s("img",{attrs:{src:"https://unsplash.it/150/300?image="+e,alt:""}}),t.video?s("svg-icon",{staticClass:"video-icon",attrs:{name:"video-camera",fill:"#fff",size:"18px"}}):i._e()],1),s("div",{staticClass:"info"},[s("div",{staticClass:"delete"},[s("v-btn",{attrs:{icon:"",flat:"",small:""}},[s("svg-icon",{attrs:{name:"bin",fill:"#fff",size:"16px"}})],1)],1),s("div",{staticClass:"item-title"},[i._v("Portrait Photography")]),s("div",{staticClass:"description"},[i._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...")]),s("div",{staticClass:"updated"},[i._v("Updated 22 October 2018")])])])])}),0):i._e(),i.vw<1024?s("div",{staticClass:"slider-container"},[s("slick",{ref:"slider",staticClass:"gallery slider",attrs:{options:i.slickOptions},on:{init:i.handleInit}},i._l(i.media,function(t,e){return s("div",{staticClass:"gallery__item"},[s("div",{staticClass:"card"},[s("div",{staticClass:"bg"},[s("img",{attrs:{src:"https://unsplash.it/150/300/?image="+(e+10),alt:""}}),t.video?s("svg-icon",{staticClass:"video-icon",attrs:{name:"video-camera",fill:"#fff",size:"18px"}}):i._e()],1),s("div",{staticClass:"info"},[s("div",{staticClass:"delete"},[s("v-btn",{attrs:{icon:"",flat:"",small:""}},[s("svg-icon",{attrs:{name:"bin",fill:"#fff",size:"16px"}})],1)],1),s("div",{staticClass:"item-title"},[i._v("Portrait Photography")]),s("div",{staticClass:"description"},[i._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...")]),s("div",{staticClass:"updated"},[i._v("Updated 22 October 2018")])])])])}),0),s("div",{staticClass:"slider__nav"})],1):i._e(),i.galleryExpanded&&i.vw>=1024?s("div",{staticClass:"extra-items gallery"},i._l(i.extraMedia,function(t,e){return s("div",{staticClass:"gallery__item"},[s("div",{staticClass:"card"},[s("div",{staticClass:"bg"},[s("img",{attrs:{src:"https://unsplash.it/150/300/?image="+(e+10),alt:""}}),t.video?s("svg-icon",{staticClass:"video-icon",attrs:{name:"video-camera",fill:"#fff",size:"18px"}}):i._e()],1),s("div",{staticClass:"info"},[s("div",{staticClass:"delete"},[s("v-btn",{attrs:{icon:"",flat:"",small:""}},[s("svg-icon",{attrs:{name:"bin",fill:"#fff",size:"16px"}})],1)],1),s("div",{staticClass:"item-title"},[i._v("Portrait Photography")]),s("div",{staticClass:"description"},[i._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed dconsectetur adipisicing elit, sed d...")]),s("div",{staticClass:"updated"},[i._v("Updated 22 October 2018")])])])])}),0):i._e()],1)],1)},a=[],l=(s("1157"),s("7ecd")),n=(s("06b9"),{components:{slick:l["a"]},props:{pageTitle:{type:String}},data:function(){return{media:[{},{video:!0},{},{video:!0},{},{video:!0},{},{video:!0},{},{video:!0}],extraMedia:[{video:!0},{},{},{},{video:!0},{},{video:!0},{},{video:!0},{},{},{video:!0}],vw:0,slickOptions:{dots:!0,infinite:!1,speed:300,prevArrow:'<span class="prev"><i class="icon fas fa-chevron-left"></i></span>',nextArrow:'<span class="next"><i class="icon fas fa-chevron-right"></i></span>',appendArrows:".slider__nav",appendDots:".slider__nav",slidesToShow:3,slidesToScroll:3,responsive:[{breakpoint:940,settings:{slidesToShow:2,slidesToScroll:2}},{breakpoint:640,settings:{slidesToShow:1,slidesToScroll:1}}]},galleryExpanded:!1}},methods:{handleInit:function(i,t){t.goTo(t.currentSlide)},toggleGallery:function(){this.galleryExpanded=!this.galleryExpanded},onResize:function(){this.vw=window.innerWidth}},mounted:function(){this.$emit("passTitle",this.pageTitle)}}),o=n,d=(s("ca6d"),s("2877")),r=s("6544"),c=s.n(r),v=s("8336"),p=s("0e8f"),u=s("a722"),f=s("269a"),m=s.n(f),g=s("0d3d"),h=Object(d["a"])(o,e,a,!1,null,null,null);t["default"]=h.exports;c()(h,{VBtn:v["a"],VFlex:p["a"],VLayout:u["a"]}),m()(h,{Resize:g["a"]})},f430:function(i,t,s){}}]);
//# sourceMappingURL=chunk-73bb42ee.js.map