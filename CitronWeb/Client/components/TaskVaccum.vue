<template>
  <section class="taskNull__content">
    <div class="layout__table">
      <div class="layout__table__row">
        <div class="layout__table__cell">
          No list created till now.
          Create hr list here.
          <div class="action__buttons">
            <router-link to="/hrm">Create hr</router-link>
          </div>
        </div>
      </div>
    </div>
  </section>
</template> 

<script>
export default {
  name: 'TaskVaccum',
  data () {
    return {
      msg: 'Citron'
    }
  }
}
</script>

<style scoped>
.taskNull__content{
  text-align: center;
  width: 100%;
}
</style>
