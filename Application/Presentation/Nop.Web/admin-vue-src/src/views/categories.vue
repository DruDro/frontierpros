<template lang="pug">
v-container(fluid)
	v-card
		v-card-title Service Categories
			v-spacer
			v-text-field(v-model="search" append-icon="search" placeholder="Search Category")
			v-spacer
			v-dialog(persistent width="100%" :max-width="600" v-model="addCategoryDialog")
				template(v-slot:activator="{on}")
					v-btn.btn.custom.primary(v-on="on" @click="getSourceCategories") Add Category
				v-card
					v-toolbar
						v-btn(icon @click="closeCategoryDialog")
							v-icon close
						v-toolbar-title Add Category
					v-form.pa-4(v-model="valid" lazy-validation ref="addCategoryForm" @submit.prevent)
						v-combobox( :loading="!sourceCategories.length" @input.native="category=$event.srcElement.value" v-model="category" item-text="Name"  item-value="Id" :return-object="true"  :items="sourceCategories" label="Category Name" placeholder="Enter Category Name, e.g.: House Cleaning" :rules="NameRules" required )
						v-card-actions
							v-spacer
							v-btn.btn.custom.transparent(@click="closeCategoryDialog") Cancel
							v-btn.btn.custom.primary(@click="createCategory") Add
		v-data-table(:search="search" :items="categories" :headers="tableHeaders")
			template(v-slot:items="props")
				td.text-center {{props.item.Id}}
				td() {{props.item.Name}}
				td.text-center {{props.item.Published}}
				td.layout.justify-center
					v-flex(shrink)
						v-btn(color="blue" dark icon @click="showEditCategoryDialog(props.item)")
							v-icon() edit
					v-flex(shrink)
						v-btn(color="red" dark icon @click="deleteCategory(props.item)")
							v-icon() delete
		v-dialog(persistent width="100%" :max-width="600"  v-model="editCategoryDialog")
			v-card
				v-toolbar
					v-btn(icon @click="closeCategoryDialog")
						v-icon close
					v-toolbar-title Edit Category
				v-form.pa-4(v-model="valid" lazy-validation ref="addCategoryForm" @submit.prevent)
					v-text-field(v-model="editCategory.Name" @input.native="editCategory.Name=$event.srcElement.value" label="New Category Name")
					v-card-actions
						v-spacer
						v-btn.btn.custom.transparent(@click="closeCategoryDialog") Cancel
						v-btn.ml-3.btn.custom.primary(@click="updateCategory") Save
</template>

<script>
import { capitalize } from "../variables";

import { APIServices } from '../api/api-services';

export default {
    data() {
        return {
			search:"",
			tableHeaders:[
				{
					text:'ID',
					value:'Id',
					align:'center',
					width:'100px'
				},
				{
					text:'Service Category Name',
					value:'Name',
					align:'left'
				},
				{
					text:'Published',
					value:'Published',
					align:'center'
				},
				{
					text:'Actions',
					value:'Name',
					sortable:false,
					width:'200px',
					align:'center'
				},
			],
            addCategoryDialog: false,
            editCategoryDialog: false,
            valid: false,
            categories: [],
            sourceCategories: [],
            category: {
                Id: null,
                Name: ""
            },
            editCategory: {
                Id: null,
                Name: ""
            },
            categoryExists: true,
            NameRules: [
                v => !!v || "Please enter the Category Name",
                v => !!v || "Category Name must be at least 3 letters"
            ]
        };
    },
    methods: {
        getCategroies() {
            APIServices
                .serviceCategories
                .getCategroies()
                .then(res => {
                    console.log(res.data);
                    this.categories = res.data;
                });
        },
        getSourceCategories() {
            APIServices
                .sources
                .getSourceCategories()
                .then(res => {
                    console.log(res.data);
                    this.sourceCategories = res.data;
                });
        },

        createCategory() {
            if (this.$refs.addCategoryForm.validate()) {
                let categoryName;
                if (typeof this.category == "string") {
                    categoryName = this.category;
                } else {
                    categoryName = this.category.Name;
                }
                APIServices
                    .serviceCategories
                    .createCategory({
                        Name: capitalize(categoryName)
                    })
                    .then(res => {
                        this.getCategroies();
                        this.closeCategoryDialog();
                    });
            }
        },
        clearAll() {
            this.addCategoryDialog = false;
            this.editCategoryDialog = false;
            this.valid = false;
            this.category = {
                Id: null,
                Name: ""
            };
            this.editCategory = {
                Id: null,
                Name: ""
            };
            this.categoryExists = true;
        },
        closeCategoryDialog() {
            this.clearAll();
        },

        // edit functionality
        showEditCategoryDialog(category) {
            this.editCategoryDialog = true;
            this.editCategory = category;
        },
        updateCategory() {
			console.log(this.editCategory)
            APIServices
                .serviceCategories
                .updateCategory({
                    Id: this.editCategory.Id,
                    Name: this.editCategory.Name
                })
                .then(res => this.closeCategoryDialog());
        },
        deleteCategory(category) {
            if (confirm(`Do you really want to delete ${category.Name}?`)) {
                APIServices
                    .serviceCategories
                    .deleteCategory(category.Id)
                    .then(res => alert("Category name deleted!"));
            }
        },
        getServiceQuestionnaire() {
            APIServices
                .questionnaires
                .getServiceQuestionnaire(this.editService.Id)
                .then(res => {
                    if (res.data) {
                        this.questionnaire = res.data;
                    } else {
                        this.createNewQuestionnaire();
                    }
                    console.log(res.data);
                    this.questionnaireOpen = true;
                });
        }
    },
    mounted() {
        this.getCategroies();
    }
};
</script>

<style lang="scss" scoped>
</style>