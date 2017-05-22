<template>
  <section class="panels__row">
    <div class="panels__headings">
      <h1>Human Resources</h1>
    </div>
    <!-- Personal details -->
    <div class="panel__box">
      <div class="panel__box__title">Personal details</div>
      <div class="form__hr">
        <form>
          <div class="row">
                <div class="col-xs-12 col-sm-7">
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Employee Id</label>
                        <input type="email" class="form-control" placeholder="Employee id">
                      </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Employee Name</label>
                        <input type="email" class="form-control" placeholder="Employee name">
                      </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Employee Name</label>
                        <input type="email" class="form-control" placeholder="Employee name">
                    </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                          <label>Employee Email</label>
                          <input type="email" class="form-control" placeholder="Employee email">
                        </div>
                      </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Birthday</label>
                        <input type="email" class="form-control" placeholder="Employee birthday">
                      </div>
                      </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Marital status</label>
                        <select class="form-control">
                          <option>Single</option>
                          <option>Marriend</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Personality Type</label>
                        <select class="form-control">
                          <option>Standard</option>
                          <option>Advanced</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Blood Group</label>
                        <select class="form-control">
                          <option>Ab+</option>
                          <option>Ab-</option>
                          <option>A</option>
                          <option>B</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                      <div class="form-group">
                        <label>Citizenship No.</label>
                         <input type="email" class="form-control" placeholder="Citizenship no.">
                      </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-5">
                    <div class="upload__profile">
                    	<div class="upload__profile__avatar">
                        <div class="img__aavatar__block">
                          <div class="img__aavatar__box">
                            <div class="img__aavatar">
                              <img src="../assets/images/user__avatar-1.jpg">
                            </div>
                            <label class="btn btn-default btn-file">
                              Browse <input type="file" style="display: none;">
                            </label>
                          </div>
                        </div>
                        
                      </div>
                    </div>
                </div>
            </div>
        </form>
      </div>
    </div>
    <!-- Contact details -->
    <div class="panel__box">
      <div class="panel__box__title">Contact details</div>
      <div class="form__hr">
        <form>
          <div class="row">
              <div class="col-xs-12">
                <div class="row">
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Local Address</label>
                      <input type="text" class="form-control" placeholder="local address">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Phone No.</label>
                      <input type="text" class="form-control" placeholder="phone no.">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Mobile No.</label>
                      <input type="text" class="form-control" placeholder="mobile no.">
                    </div>
                  </div>
                </div>
              </div>
          </div>
          <div class="row">
              <div class="col-xs-12">
                <div class="row">
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Permanent Address</label>
                      <input type="text" class="form-control" placeholder="local address">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Phone No.</label>
                      <input type="text" class="form-control" placeholder="phone no.">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Mobile No.</label>
                      <input type="text" class="form-control" placeholder="mobile no.">
                    </div>
                  </div>
                </div>
              </div>
          </div>
          <div class="row">
              <div class="col-xs-12">
                <div class="row">
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Emmergency Address</label>
                      <input type="text" class="form-control" placeholder="local address">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Phone No.</label>
                      <input type="text" class="form-control" placeholder="phone no.">
                    </div>
                  </div>
                  <div class="col-xs-12 col-sm-4">
                    <div class="form-group">
                      <label>Mobile No.</label>
                      <input type="text" class="form-control" placeholder="mobile no.">
                    </div>
                  </div>
                </div>
              </div>
          </div>
         
        </form>
      </div>
    </div>
            <div class="action__buttons action__buttons--center">
                <button type="submit" value="Submit" class="button button--green">Submit</button>
                <button type="submit" value="Submit" class="button button--red">Cancel</button>
            </div>
  </section>
</template> 

<script>
export default {
  name: 'CreateNewHr',
  data () {
    return {
      msg: 'Citron'
    }
  }
}
</script>

<style scoped>
.form__hr{
  width: 100%;
  margin-top: 30px;
}
.upload__profile__avatar{
  text-align: center;
}
.img__aavatar__box{
  max-width: 220px;
  display: inline-block;
}
</style>
