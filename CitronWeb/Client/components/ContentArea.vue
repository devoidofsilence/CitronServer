<template>
  <div class="app__contentpage">
      <div class="app__contentpage__wrapper container-fluid">
        <!--<TaskVaccum></TaskVaccum>-->
        <router-view></router-view>
      </div>
  </div>
</template> 

<script>
import TaskVaccum from './TaskVaccum'
export default {
  name: 'ContentArea',
  data () {
    return {
      msg: 'Citron'
    }
  },
  components: {
    TaskVaccum
  }
}
</script>

<style scoped>
.app__topbar__brand{
    float: left;
    text-align: center;
    height: 60px;
    position: relative;
    width: 130px;
    z-index: 1;
}
.user__box .nav > li > a{
  padding-top:0px;
  padding-bottom:0px; 
  line-height: 60px;
}
.user__box .user-img {
    position: relative;
    height: 36px;
    width: 36px;
    margin: 0 auto;
}
</style>
