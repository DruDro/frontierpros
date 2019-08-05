(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2ca01d64"],{2677:function(t,e,i){"use strict";i.d(e,"a",function(){return u});var a=i("8654"),n=i("a844"),r=i("7cf7"),s=i("ab6d"),o=i("d9bd"),u={functional:!0,$_wrapperFor:a["a"],props:{textarea:Boolean,multiLine:Boolean},render:function(t,e){var i=e.props,l=e.data,c=e.slots,d=e.parent;Object(s["a"])(l);var h=Object(r["a"])(c(),t);return i.textarea&&Object(o["d"])("<v-text-field textarea>","<v-textarea outline>",u,d),i.multiLine&&Object(o["d"])("<v-text-field multi-line>","<v-textarea>",u,d),i.textarea||i.multiLine?(l.attrs.outline=i.textarea,t(n["a"],l,h)):t(a["a"],l,h)}}},"269a":function(t,e){t.exports=function(t,e){var i="function"===typeof t.exports?t.exports.extendOptions:t.options;for(var a in"function"===typeof t.exports&&(i.directives=t.exports.options.directives),i.directives=i.directives||{},e)i.directives[a]=i.directives[a]||e[a]}},"26e5":function(t,e,i){},"4bd4":function(t,e,i){"use strict";i("26e5");var a=i("94ab");e["a"]={name:"v-form",mixins:[Object(a["b"])("form")],inheritAttrs:!1,props:{value:Boolean,lazyValidation:Boolean},data:function(){return{inputs:[],watchers:[],errorBag:{}}},watch:{errorBag:{handler:function(){var t=Object.values(this.errorBag).includes(!0);this.$emit("input",!t)},deep:!0,immediate:!0}},methods:{watchInput:function(t){var e=this,i=function(t){return t.$watch("hasError",function(i){e.$set(e.errorBag,t._uid,i)},{immediate:!0})},a={_uid:t._uid,valid:void 0,shouldValidate:void 0};return this.lazyValidation?a.shouldValidate=t.$watch("shouldValidate",function(n){n&&(e.errorBag.hasOwnProperty(t._uid)||(a.valid=i(t)))}):a.valid=i(t),a},validate:function(){var t=this.inputs.filter(function(t){return!t.validate(!0)}).length;return!t},reset:function(){for(var t=this,e=this.inputs.length;e--;)this.inputs[e].reset();this.lazyValidation&&setTimeout(function(){t.errorBag={}},0)},resetValidation:function(){for(var t=this,e=this.inputs.length;e--;)this.inputs[e].resetValidation();this.lazyValidation&&setTimeout(function(){t.errorBag={}},0)},register:function(t){var e=this.watchInput(t);this.inputs.push(t),this.watchers.push(e)},unregister:function(t){var e=this.inputs.find(function(e){return e._uid===t._uid});if(e){var i=this.watchers.find(function(t){return t._uid===e._uid});i.valid&&i.valid(),i.shouldValidate&&i.shouldValidate(),this.watchers=this.watchers.filter(function(t){return t._uid!==e._uid}),this.inputs=this.inputs.filter(function(t){return t._uid!==e._uid}),this.$delete(this.errorBag,e._uid)}}},render:function(t){var e=this;return t("form",{staticClass:"v-form",attrs:Object.assign({novalidate:!0},this.$attrs),on:{submit:function(t){return e.$emit("submit",t)}}},this.$slots.default)}}},"59f0":function(t,e,i){"use strict";var a=i("b705"),n=i.n(a);n.a},"7cf7":function(t,e,i){"use strict";function a(t,e){var i=[];for(var a in t)t.hasOwnProperty(a)&&i.push(e("template",{slot:a},t[a]));return i}i.d(e,"a",function(){return a})},"7e63":function(t,e,i){},a844:function(t,e,i){"use strict";i("7e63");var a=i("8654"),n=i("d9bd"),r=Object.assign||function(t){for(var e=1;e<arguments.length;e++){var i=arguments[e];for(var a in i)Object.prototype.hasOwnProperty.call(i,a)&&(t[a]=i[a])}return t};e["a"]={name:"v-textarea",extends:a["a"],props:{autoGrow:Boolean,noResize:Boolean,outline:Boolean,rowHeight:{type:[Number,String],default:24,validator:function(t){return!isNaN(parseFloat(t))}},rows:{type:[Number,String],default:5,validator:function(t){return!isNaN(parseInt(t,10))}}},computed:{classes:function(){return r({"v-textarea":!0,"v-textarea--auto-grow":this.autoGrow,"v-textarea--no-resize":this.noResizeHandle},a["a"].options.computed.classes.call(this,null))},dynamicHeight:function(){return this.autoGrow?this.inputHeight:"auto"},isEnclosed:function(){return this.textarea||a["a"].options.computed.isEnclosed.call(this)},noResizeHandle:function(){return this.noResize||this.autoGrow}},watch:{lazyValue:function(){!this.internalChange&&this.autoGrow&&this.$nextTick(this.calculateInputHeight)}},mounted:function(){var t=this;setTimeout(function(){t.autoGrow&&t.calculateInputHeight()},0),this.autoGrow&&this.noResize&&Object(n["b"])('"no-resize" is now implied when using "auto-grow", and can be removed',this)},methods:{calculateInputHeight:function(){var t=this.$refs.input;if(t){t.style.height=0;var e=t.scrollHeight,i=parseInt(this.rows,10)*parseFloat(this.rowHeight);t.style.height=Math.max(i,e)+"px"}},genInput:function(){var t=a["a"].options.methods.genInput.call(this);return t.tag="textarea",delete t.data.attrs.type,t.data.attrs.rows=this.rows,t},onInput:function(t){a["a"].options.methods.onInput.call(this,t),this.autoGrow&&this.calculateInputHeight()},onKeyDown:function(t){this.isFocused&&13===t.keyCode&&t.stopPropagation(),this.internalChange=!0,this.$emit("keydown",t)}}}},ab6d:function(t,e,i){"use strict";function a(t){if(t.model&&t.on&&t.on.input)if(Array.isArray(t.on.input)){var e=t.on.input.indexOf(t.model.callback);e>-1&&t.on.input.splice(e,1)}else delete t.on.input}i.d(e,"a",function(){return a})},b705:function(t,e,i){},e951:function(t,e,i){"use strict";i.r(e);var a=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("v-flex",{staticClass:"page-sidebar"},[a("div",{staticClass:"chat",attrs:{id:"chaat",hidden:t.$vuetify.breakpoint.width<1024}},[a("v-badge",{attrs:{color:"white"}},[a("v-avatar",{directives:[{name:"ripple",rawName:"v-ripple"}],staticClass:"raised",attrs:{size:"86",color:"primary"}},[a("svg-icon",{attrs:{name:"talk",size:"40px",fill:"#fff"}})],1),a("span",{attrs:{slot:"badge"},slot:"badge"},[t._v("1")])],1)],1),a("div",{staticClass:"sidebar__title"},[t._v("TEAM")]),a("v-form",[a("v-layout",{attrs:{row:"",nowrap:"","align-center":""}},[a("v-flex",{attrs:{grow:""}},[a("v-text-field",{attrs:{label:"Enter Name"}})],1),a("v-flex",{attrs:{shrink:""}},[a("v-btn",{attrs:{icon:""}},[a("svg-icon",{attrs:{name:"plus",size:"25px",fill:"#7094f7"}})],1)],1)],1)],1),a("div",{staticClass:"service__team"},t._l(3,function(e){return a("div",{staticClass:"teammate"},[a("a",{directives:[{name:"ripple",rawName:"v-ripple"}],staticClass:"remove",attrs:{href:"#"}},[a("svg-icon",{attrs:{name:"close",size:"14px",fill:"#7094f7"}})],1),a("v-avatar",{attrs:{size:"50"}},[a("img",{attrs:{src:i("14ce")}})]),a("div",{staticClass:"teammate__info"},[a("div",{staticClass:"name"},[t._v("Melissa Dunn")]),a("div",{staticClass:"pos"},[t._v("Developer")])]),a("a",{directives:[{name:"ripple",rawName:"v-ripple"}],staticClass:"see",attrs:{href:"#"}},[a("svg-icon",{attrs:{name:"eye",width:"19px",height:"15px",fill:"#7094f7"}})],1)],1)}),0)],1)},n=[],r={props:{pageTitle:{type:String}},mounted:function(){this.$emit("passTitle",this.pageTitle)}},s=r,o=(i("59f0"),i("2877")),u=i("6544"),l=i.n(u),c=i("8212"),d=i("4ca6"),h=i("8336"),p=i("0e8f"),f=i("4bd4"),v=i("a722"),m=i("2677"),g=i("269a"),w=i.n(g),x=i("3ccf"),b=Object(o["a"])(s,a,n,!1,null,null,null);e["default"]=b.exports;l()(b,{VAvatar:c["a"],VBadge:d["a"],VBtn:h["a"],VFlex:p["a"],VForm:f["a"],VLayout:v["a"],VTextField:m["a"]}),w()(b,{Ripple:x["a"]})}}]);
//# sourceMappingURL=chunk-2ca01d64.js.map