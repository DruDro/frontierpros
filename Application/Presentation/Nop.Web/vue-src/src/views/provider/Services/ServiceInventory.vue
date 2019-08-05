<template lang="pug">
.tab-content
	.card.pa-0(v-if="$vuetify.breakpoint.mdAndUp")
		div.service__inventory
			v-data-table.inventory-table(
				disable-initial-sort=true
				hide-actions
				:headers="headers"
				:items="inventories")
				span(slot="progress")
				template(slot="items" slot-scope="props" )
					td.image.text-xs-center
						v-img.mx-auto(:src="props.item.image" width="64"  aspect-ratio="1")
					td.name() {{ props.item.name }}
					td.text-xs-left.price
						| ${{ props.item.price }}
					td.text-xs-left.quantity
						v-text-field(:value="props.item.quantity")
					td.description.text-xs-left
						| {{ props.item.description }}
					td.text-xs-right
						switcher.green-pink(:checked="props.item.active" @click.native="inventories[props.index].active = !inventories[props.index].active")
	div.service__inventory(v-if="$vuetify.breakpoint.smAndDown")
		v-layout.card.inventory(mx-0 mt-0 mb-4 v-for="(item,index) in inventories" :key="index" row wrap align-center justify-center)
			v-flex.image.text-xs-center.mr-4.mb-2(shrink)
				v-img.mx-auto(:src="item.image" width="64"  aspect-ratio="1")
			v-flex.name.mb-2() {{ item.name }}				
				v-layout.flex(align-start mt-2)
					v-flex.text-xs-left.price(shrink  mr-4)
						label.font-weight-bold.d-block.mb-2 Price
						| ${{ item.price }}
					v-flex.text-xs-left.quantity(shrink)
						label.font-weight-bold.d-block.mb-2 Quantity
						v-text-field.pa-0.ma-0(height="20" :value="item.quantity" hide-details=true)
			v-flex.description.text-xs-left(xs12)
				| {{ item.description }}
			v-flex.text-xs-right(xs12 mt-4)
				switcher.green-pink(:checked="item.active" @click.native="inventories[index].active = !inventories[index].active")
</template>
<script>
export default {
  props: {
    pageTitle: {
      type: String
    }
  },
  data() {
    return {
      headers: [
        {
          text: "Image",
          value: "image",
          sortable: false
        },
        {
          text: "Name",
          value: "name",
          sortable: false
        },
        {
          text: "Price",
          value: "price",
          sortable: false
        },
        {
          text: "Quantity",
          value: "quantity",
          sortable: false
        },
        {
          text: "Description",
          value: "description",
          sortable: false
        },
        {
          text: "Active",
          value: "active",
          sortable: false
        }
      ],
      inventories: [
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 2,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: true
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 0,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: false
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 1,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: true
        },
        {
          image: `https://picsum.photos/200/300/?random`,
          name: "Inventory Name",
          price: 45,
          quantity: 1,
          description:
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in",
          active: true
        }
      ]
    };
  },
  methods:{
  },
  mounted() {
    this.$emit("passTitle", this.pageTitle);
  }
};
</script>

<style lang="scss" >
.inventory-table {
  border-collapse: collapse;
  border: 0 !important;
  background: transparent;
  th,
  td,
  tr {
    border: 0 !important;
  }
  thead th {
    border-bottom: 1px solid #bababa !important;
    font-weight: bold;
  }
  th,
  td {
    padding: 15px 20px !important;
    font-size: 18px !important;
    color: #1c1c1c !important;
    &.description {
      word-wrap: break-word;
      white-space: normal;
    }
    &.image {
      .v-image__image,
      img {
        border-radius: 10px;
        overflow: hidden;
      }
    }
  }
  td {
    font-weight: 300;
    line-height: normal;
  }
  thead {
    tr:first-child {
      border-bottom: 0 !important;
    }
    .v-datatable__progress {
      display: none;
    }
  }

  @include b(959) {
    thead {
      display: none;
    }
    tr {
      box-shadow: 0 15px 30px rgba(#7498fc, 0.1);
      border-radius: 20px;
      padding: 15px;
      overflow: auto;
      & + tr {
        margin-top: 40px;
      }
    }
    tr,
    tbody {
      display: block;
      width: 100%;
      height: auto;
      td,
      th {
        display: block;
        height: auto;
      }
    }
  }
}
</style>

