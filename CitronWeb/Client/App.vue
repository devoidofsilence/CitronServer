<template>
  <div id="app">
    <SiteHeader></SiteHeader>
    <AsidePanelMenu></AsidePanelMenu>
    <ContentArea></ContentArea>
  </div>
</template> 

<script>
  import SiteHeader from './components/SiteHeader'
  import AsidePanelMenu from './components/AsidePanelMenu'
  import ContentArea from './components/ContentArea'

export default {
  name:'app',
  components:{
    SiteHeader,
    AsidePanelMenu,
    ContentArea

  },
  data () {
    return {}
}
}
</script>

<style>
#app{
    width: 100%;
    background-color: #f5f5f5;
}
</style>
