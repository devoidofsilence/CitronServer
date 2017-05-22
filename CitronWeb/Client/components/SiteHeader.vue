<template>
  <header class="site__header app__topbar">
    <div class="app__topbar__brand">
      <a href="" class="brand__name">Citron</a>
    </div>
    <div class="app__topbar__status container-fluid">
      <div class="user__box">
        <ul class="nav navbar-nav navbar-right">
          <li>
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">HR Module</a>
          <ul class="dropdown-menu">
              <li><router-link to="/hrm">Create hr</router-link></li>
              <li><a href="#">Go to hr</a></li>
            </ul>
          
          </li>
          <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
              <img src="../assets/images/user__avatar-1.jpg" class="img-circle user-img">
              </a>
            <ul class="dropdown-menu">
              <li><a href="#">Profile</a></li>
              <li><a href="#">Settings</a></li>
              <li><a href="#">Logout</a></li>
              
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </header>
</template> 

<script>
export default {
  name: 'SiteHeader',
  data () {
    return {
      msg: 'Citron'
    }
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
