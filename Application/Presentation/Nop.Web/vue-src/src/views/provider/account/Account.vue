<template lang="pug">
	.container
		.placeholder( v-if="profile" )
			.mx-auto(style="width:870px;max-width:100%;")
				.stepper(:style="{margin:`0 calc(-100% / ${steps.length * 2}) 40px`}")
					a.step__link(v-for="(step,i) in steps" @click.prevent="gotoStep(i)" :key="i" :class="{disabled: i > 0 ? !steps[i-1].completed : false, completed:step.completed, active: i == stepIndex }")
						span.step__link-text {{step.text}}
				transition
					router-view(@setCompanyType="setCompanyType" @next="next")
			v-card-actions.my-4
				v-layout.tab-pager()
					v-flex( shrink v-if="stepIndex > 0")
						a.prev-link(@click.prevent="prev")
							span Previous Page
					v-flex( shrink ml-5 v-if="stepIndex < steps.length - 1 && steps[stepIndex+1].completed")
						a.next-link(@click.prevent="next")
							span Next Page
				v-spacer
				v-btn.btn.custom.transparent(flat @click="saveForm(stepIndex, false)"  ) Save and Finish Later
				v-btn.btn.custom.primary(flat  @click="saveForm(stepIndex, true)") Continue
		.text-xs-center(v-else)
			v-progress-circular(:size="50" color="primary" indeterminate)
		v-layout(align-stretch fluid py-0 )
			v-dialog(v-model="addServicePopup" persistent max-width="700px")
				card.py-5
					v-card-title You are all set
					v-card-text Please proceed
					v-card-actions.text-center.mt-3.mx-auto(style="width: 300px; max-width:100%")
						v-container(text-xs-center grid-list-xl)
							v-layout(justify-center)
								v-flex(shrink)
									v-btn.btn.custom.primary(flat @click="addNewServiceItem") Add Service
								v-flex(shrink)
									v-btn.btn.custom.transparent(flat @click="gotoProfilePage") Go to Profile
</template>

<script>
import { APIServices } from "../../../api/api-services";

export default {
	data() {
		return {
			profile:null,
			addServicePopup: false,
			stepIndex: 0,
			personalInfo: null,
			companyType:null
		};
	},
	computed: {
		steps: function() {
			return [
				{
					path: "personal-info",
					text: "Personal info"
				},
				{
					path: `${this.companyType}-info`,
					text: "Profile"
				}
				// {
				//     path: `./leads`,
				//     text: "Leads"
				// },
				// {
				//     path: `./plans`,
				//     text: "Plans"
				// },
				// {
				//     path: `./payment-methods`,
				//     text: "Payment Methods"
				// }
			];
		}
	},
	methods: {
		setCompanyType(e) {
			this.companyType = e ? "individual" : "business";
		},
		gotoStep(i){
			this.stepIndex = i;
			this.$router.push(this.steps[this.stepIndex].path);
		},
		prev() {
			this.stepIndex--;
			if (this.steps[this.stepIndex]) {
				this.$router.push(this.steps[this.stepIndex].path);
			} else {
				this.stepIndex++;
			}
		},
		next() {
			this.stepIndex++;
			if (this.steps[this.stepIndex]) {
				this.$router.push(this.steps[this.stepIndex].path);
			} else {
				this.stepIndex--;
				this.addServicePopup = true;
			}
		},
		saveForm(stepIndex, nextStep) {
			if(stepIndex == 0){//personal-info
				this.savePersonalInfo(nextStep);
				
			}else if(stepIndex == 1){
				if(this.profile.IsIndividualCompany){//individual-info
					this.saveIndividualInfo(nextStep);
				}else{//business=info
					this.saveBusinessInfo(nextStep);
				}
			}
		},
		savePersonalInfo(nextStep) {
			
			APIServices
				.providers
				.setPersonalInfo({
					"Id": this.profile.Id,
					"Name": this.profile.Name,
					"Surname": this.profile.Surname,
					"Gender": this.profile.Gender,
					"BirthdayDay": this.profile.BirthdayDay,
					"BirthdayMonth": this.profile.BirthdayMonth,
					"BirthdayYear": this.profile.BirthdayYear,
					"Country": this.profile.Country,
					"State": this.profile.State,
					"City": this.profile.City,
					"PersonalAddress": this.profile.PersonalAddress,
					"IsIndividualCompany": this.profile.IsIndividualCompany
				})
				.then((res) => {
					console.log(res);
					if(res.data && res.data.success){
						this.steps[this.stepIndex].completed = true;
						if(nextStep){
							this.next();
						}else{
							this.$router.push(`/provider/profile`);
						}
					}
				})
				.catch(function(error) {
					self.smsError = true;
					console.log(error);
				});
		},
		saveIndividualInfo(nextStep) {
			APIServices
				.providers
				.setIndividualInfo({
					"Id": this.profile.Id,
					"Address": this.profile.Address,
					"Website": this.profile.Website,
					"WhyShouldCustomerHireYou": this.profile.WhyShouldCustomerHireYou,
					"YourIntroduction": this.profile.YourIntroduction,
					"PhoneNumber": this.profile.PhoneNumber,
					"FoundedYear": this.profile.FoundedYear
				})
				.then((res) => {
					console.log(res);
					if(res.data && res.data.success){
						this.steps[this.stepIndex].completed = true;
						if(nextStep){
							this.next();
						}else{
							this.$router.push(`/provider/profile`);
						}
					}
				})
				.catch(function(error) {
					self.smsError = true;
					console.log(error);
				});
		},
		saveBusinessInfo(nextStep) {
			APIServices
				.providers
				.setBusinessInfo({
					"Id": this.profile.Id,
					"CompanyName": this.profile.CompanyName,
					"Address": this.profile.Address,
					"Website": this.profile.Website,
					"WhyShouldCustomerHireYou": this.profile.WhyShouldCustomerHireYou,
					"YourIntroduction": this.profile.YourIntroduction,
					"PhoneNumber": this.profile.PhoneNumber,
					"FoundedYear": this.profile.FoundedYear
				})
				.then((res) => {
					console.log(res);
					if(res.data && res.data.success){
						this.steps[this.stepIndex].completed = true;
						if(nextStep){
							this.next();
						}else{
							this.$router.push(`/provider/profile`);
						}
					}
				})
				.catch(function(error) {
					self.smsError = true;
					console.log(error);
				});
		},
		gotoProfilePage(){
			this.$router.push(`/provider/profile`);
		},
		addNewServiceItem() {
			APIServices
				.serviceItems
				.createServiceItem({})
				.then((res) => {
					console.log(res);
					if(res.data && res.data.success){
						if(res.data.id > 0){
							this.$router.push(`/provider/services/${res.data.Id}/service-info`);
						}
					}
				})
				.catch(function(error) {
					self.smsError = true;
					console.log(error);
				});
		}
	},
	mounted() {
		this.$store.dispatch("GET_PROFILE", "provider").then(profile => {
			this.profile = profile;
			this.companyType = this.profile.IsIndividualCompany ? 'individual' : 'business';
			
			let PHONE_CONFIRMATION = 1;
			let PERSONAL_INFO = 2;
			let INDIVIDUAL_INFO = 4;
			let BUSINESS_INFO = 8;
			let progress = 0;
			progress = this.profile.Progress;

			let phoneConfirmationDone = progress & PHONE_CONFIRMATION;
			let personalInfoDone = progress & PERSONAL_INFO;
			let individualInfoDone = progress & INDIVIDUAL_INFO;
			let businessInfoDone = progress & BUSINESS_INFO;

			this.steps[0].completed = personalInfoDone;
			this.steps[1].completed = individualInfoDone || businessInfoDone;

			if (!phoneConfirmationDone) {
				this.$router.push(`/provider/configure-profile`);
			}else if(!personalInfoDone){
				this.stepIndex = 0;
				this.$router.push(`/provider/account/${this.steps[this.stepIndex].path}`);
				//this.$router.push(`/provider/account/personal-info`);
			}else if(this.profile.IsIndividualCompany && !individualInfoDone){
				this.stepIndex = 1;
				this.$router.push(`/provider/account/${this.steps[this.stepIndex].path}`);
				//this.$router.push(`/provider/account/individual-info`);
			}else if (!this.profile.IsIndividualCompany && !businessInfoDone){
				this.stepIndex = 1;
				this.$router.push(`/provider/account/${this.steps[this.stepIndex].path}`);
				//this.$router.push(`/provider/account/business-info`);
			}
			else{
				this.$router.push(`/provider/services`);
			}
		});
	}
};
</script>

<style lang="scss" >
.stepper {
	display: flex;
	flex-flow: row nowrap;
	justify-content: space-between;
	.step {
		&__link {
			height: 55px;
			position: relative;
			flex: 1 1 auto;
			&:before {
				content: "";
				border-bottom: 2px solid #e1e1e1;
				width: 100%;
				position: absolute;
				bottom: 0;
				left: -50%;
			}
			&:first-of-type {
				&:before {
					display: none;
				}
			}
			&-text {
				position: absolute;
				transform: translateX(-50%);
				left: 50%;
				text-transform: capitalize;
				white-space: nowrap;
				z-index: 1;
				height: 100%;
				&:before {
					content: "";
					position: absolute;
					width: 10px;
					height: 10px;
					background: #e1e1e1;
					border-radius: 50%;
					top: 50px;
					left: 50%;
					transform: translateX(-50%);
				}
			}
			&.disabled {
				pointer-events: none;
				.step__link-text {
					color: #7094f7;
				}
			}
			&.completed,
			&.active {
				.step__link-text:before {
					background: #7094f7;
					width: 30px;
					height: 30px;
					top: 40px;
				}
				.step__link-text:after {
					content: "";
					width: 10px;
					height: 6px;
					border: 2px solid white;
					border-width: 0 0 2px 2px;
					top: 100%;
					left: 50%;
					position: absolute;
					transform: rotate(-45deg) translate(-50%, -50%);
					transform-origin: 0 0;
				}
			}
			&.completed,
			&.active {
				&:before {
					border-color: rgb(112, 148, 247);
				}
			}
			&.active {
				.step__link-text {
					font-weight: bold;
					&:after {
						content: "";
						width: 10px;
						height: 10px;
						border-radius: 50%;
						top: 100%;
						left: 50%;
						position: absolute;
						transform: translate(-50%, -50%);
						background: white;
					}
				}
			}
		}
	}
}

.custom-label,
.v-text-field .v-label {
	font-size: 18px;
	color: rgb(28, 28, 28) !important;
	font-weight: bold;
	transform: translateY(-35px);
}
.v-text-field .v-label--active {
	transform: translateY(-35px);
}

.tab-pager {
	a {
		font-size: 18px;
		font-weight: 300;
		display: inline-block;
		white-space: nowrap;
		span {
			padding: 0 0 2px;
			border-bottom: 1px solid transparent !important;
		}
		& + a {
			margin-left: 30px;
		}
		&:before,
		&:after {
			content: "";
			width: 12px;
			height: 12px;
			font-size: 18px;
			vertical-align: middle;
			color: currentColor;
			border-style: solid;
			border-width: 1px 1px 0 0;
			background-color: currentColor currentColor transparent transparent;
			display: inline-block;
			transform: rotate(45deg);
		}
		&:before {
			margin-right: 5px;
			transform: rotate(225deg);
		}
		&:after {
			margin-left: 5px;
		}
		&.prev-link:after {
			display: none !important;
		}
		&.next-link:before {
			display: none;
		}
		&:hover {
			span {
				border-bottom-color: currentColor !important;
				font-weight: 700;
			}
		}
	}
}
</style>