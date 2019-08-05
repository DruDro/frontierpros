<template lang="pug">
.tab-content
	v-layout(row wrap align-center justify-space-between)
		v-flex(xs12 sm8 xl10 :class="{'pr-0 pb-4': $vuetify.breakpoint.xs, 'pr-4': $vuetify.breakpoint.smAndUp}")
			b Professional Licenses
			p Please provide your license information below for your profile “HenLicense Typery Carpenter”. A FrontierPros team member will check the license information you provide against the states public licensing database. If we are able to locate the license under your name and business, we will display the license information on your profile.
		v-flex(xs12 sm4 xl2)
			v-btn.btn.custom.large.primary.full-width(flat @click="addLicense()") Add New
	.card.my-5.licenses
		a.license(v-for="license in profile.Licenses" style="color:#7094f7" @click-native="updateLicense") {{license.LicenseNumber}}
			v-btn(flat icon @click="deleteLicense(license)")
				svg-icon.ml-2(name="close" size="13px" fill="#7094f7")
	p
		b Why Show Your Licence?
	p For certain services, customers prefer to hire professionals who are licensed in their profession. In other cases, licenses are required for the job.
	br
	p
		b What kind of license can I upload to display on my profile?
	p FrontierPros allows you to display an occupational or professional license. We do not display business licenses or registrations because those do not showcase occupational credentials.
	v-layout(align-stretch fluid py-0 )
		v-dialog(v-model="editLicensePopup" persistent max-width="700px")
			card.py-5
				v-btn(flat icon @click="editLicensePopup = false")
					svg-icon.ml-2(name="close" size="13px" fill="#7094f7")
				h4.text-uppercase.text-center.mt-4 Add New License
				v-text-field.mt-4(label="State" type="text" placeholder="Enter Your State" v-model="licenseModel.State")
				v-text-field.mt-4(label="License Type" type="text" placeholder="Enter Your Type" v-model="licenseModel.LicenseType")
				v-text-field.mt-4(label="License Number" type="text" placeholder="Enter Your Number" required v-model="licenseModel.LicenseNumber")
				.text-center.mt-3.mx-auto(style="width: 250px;")
					v-btn.btn.primary.custom.full-width.large(@click="saveLicense()") Save
</template>
<script>
import { mapState } from "vuex";

import { APIServices } from "../../../api/api-services";

export default {
    props: {
        pageTitle: {
            type: String
		}
	},methods: {
        deleteLicense(license){
			if(confirm("Do you realy want to delete profile license?")) {
				APIServices
					.providerLicences
					.deleteLicense(license.Id)
					.then((res) => {
						console.log(res);
						if(res.data && res.data.success){
							this.profile.Licenses.splice(this.profile.Licenses.indexOf(license), 1);    
						}
					})
					.catch(function(error) {
						self.smsError = true;
						console.log(error);
					});
			}
		},
		updateLicense(license){
			this.showEditLicensePopup(license);
		},
		addLicense(){
			var model = {
				Id:0,
				LicenseNumber:"",
				LicenseType:"",
				State:""
			};
			this.showEditLicensePopup(model);
		},
		showEditLicensePopup(license){
			this.licenseModel.Id = license.Id;
			this.licenseModel.LicenseNumber = license.LicenseNumber;
			this.licenseModel.LicenseType = license.LicenseType;
			this.licenseModel.State = license.State;
			this.editLicensePopup = true;
		},
		saveLicense(){
			if(this.licenseModel.Id === 0) {
				APIServices
					.providerLicences
					.addLicense(this.licenseModel)
					.then((res) => {
						console.log(res);
						if(res.data && res.data.success){
							this.licenseModel.Id = res.data.id;
							this.profile.Licenses.push(this.licenseModel);
							this.editLicensePopup = false;
						}
					})
					.catch(function(error) {
						self.smsError = true;
						console.log(error);
						this.editLicensePopup = false;
					});
			}else{
				APIServices
					.providerLicences
					.editLicense(this.licenseModel)
					.then((res) => {
						console.log(res);
						if(res.data && res.data.success){
							license.LicenseNumber = this.licenseModel.LicenseNumber;
							license.LicenseType = this.licenseModel.LicenseType;
							license.State = this.licenseModel.State;
							this.editLicensePopup = false;
						}
					})
					.catch(function(error) {
						self.smsError = true;
						console.log(error);
						this.editLicensePopup = false;
					});
			}
		}
	},
	data(){
		return {
			licenseModel:{
				Id:0,
				LicenseNumber:"",
				LicenseType:"", 
				State:""
			},
			editLicensePopup:false
		};
	},
	computed: {
	...mapState(["profile"])
	},
    mounted() {
        this.$emit("passTitle", this.pageTitle);
    }
};
</script>

<style lang="scss">
	.licenses{
		.license{
			display: inline-block;
			vertical-align: top;
			margin:10px 40px 10px 0
		}
		@include b(tablet){
			padding: 15px;
		}
	}
</style>

