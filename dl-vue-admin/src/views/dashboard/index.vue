<template>
  <div class="dashboard-container">
    <div class="dashboard-text">欢迎光临:{{ name }} </div>

    <el-row :gutter="20">
      <el-col :span="6">
        <el-card class="box-card">
          <el-col :span="12">
            <svg-icon icon-class="documentation" />
          </el-col>
          <el-col :span="12">
            <div class="card-panel-text">{{ $t('dashboard.document') }}</div>
            <div class="card-panel-num">
              <a href="#" target="_blank">Document</a>
            </div>
          </el-col>
        </el-card>
      </el-col>
      <el-col :span="6">
        <el-card class="box-card">
          <el-col :span="12">
            <svg-icon icon-class="user" />
          </el-col>
          <el-col :span="12">
            <div class="card-panel-text">{{ $t('dashboard.newUser') }}</div>
            <div class="card-panel-num">102,400</div>
          </el-col>
        </el-card>
      </el-col>
      <el-col :span="6">
        <el-card class="box-card">
          <el-col :span="12">
            <svg-icon icon-class="message" />
          </el-col>
          <el-col :span="12">
            <div class="card-panel-text">{{ $t('dashboard.message') }}</div>
            <div class="card-panel-num">5</div>
          </el-col>
        </el-card>
      </el-col>
      <el-col :span="6">
        <el-card class="box-card">
          <el-col :span="12">
            <svg-icon icon-class="money" />
          </el-col>
          <el-col :span="12">
            <div class="card-panel-text">{{ $t('dashboard.income') }}</div>
            <div class="card-panel-num">10000</div>
          </el-col>
        </el-card>
      </el-col>
    </el-row>

    <el-row>
      <el-col :span="24">
        <div class="chart section">
          <v-chart :options="lineData" />
        </div>
      </el-col>
    </el-row>

    <el-row :gutter="20">
      <el-col :span="12">
        <el-collapse class="section">
          <el-collapse-item title="完善防控 各地千方百计复工达产" name="1">
            <div><a href="#" target="_blank">点击查看详情</a></div>
          </el-collapse-item>
          <el-collapse-item title="车企营业：超跑厂里缝口罩 造F1赛车的做呼吸机" name="2">
            <div><a href="#" target="_blank">点击查看详情</a> </div>
          </el-collapse-item>
          <el-collapse-item title="iOS被曝严重安全漏洞 5亿部苹果手机有潜在风险" name="3">
            <div><a href="#" target="_blank">点击查看详情</a> </div>
          </el-collapse-item>
          <el-collapse-item title="电子商务促消费升级 每天快递量超2亿件" name="4">
            <div><a href="#" target="_blank">点击查看详情</a> </div>
          </el-collapse-item>
          <el-collapse-item title="十年禁捕，长江保护分秒必争" name="5">
            <div><a href="#" target="_blank">点击查看详情</a> </div>
          </el-collapse-item>
          <el-collapse-item title="台积电挑战业界巅峰：即将研发1nm工艺" name="6">
            <div><a href="#" target="_blank">点击查看详情</a> </div>
          </el-collapse-item>

        </el-collapse>
      </el-col>

      <el-col :span="12">
        <v-chart :options="barData" class="chart section" />
      </el-col>
    </el-row>

    <el-row :gutter="20">
      <el-col :span="12">
        <v-chart :options="pieData" class="chart section" />
      </el-col>
      <el-col :span="12">
        <el-table :data="tableData" class="section">
          <el-table-column
            prop="date"
            :label="$t('dashboard.date')"
            width="180"
          />
          <el-table-column
            prop="name"
            :label="$t('dashboard.name')"
            width="180"
          />
          <el-table-column
            prop="address"
            :label="$t('dashboard.addr')"
          />
        </el-table>

      </el-col>

    </el-row>
  </div>
</template>

<script src="./dashboard.js"></script>
<style rel="stylesheet/scss" lang="scss" scoped>
  .el-row{
    margin-bottom: 20px;
    &:last-child {
      margin-bottom: 0;
    }
  }

.dashboard {

  &-container {
    padding: 15px;
    background-color: #f0f2f5;
  }
  &-text {
    font-size: 14px;
    line-height: 22px;
    padding-bottom:15px;
  }
}
.echarts{
  width: 100%;
  height: 100%;
}
.box-card{
  height:108px;
}
  .chart{
    height: 350px;
  }
  .section{
    padding:20px;
    background-color: white;
    border: 1px solid #ebeef5;
    box-shadow: 0 2px 12px 0 rgba(0,0,0,.1);
  }

  .box-card > div >div > .svg-icon {
    width: 4em;
    height: 4em;
    color:#34bfa3;
  }
  .card-panel-text{
    padding-top:10px;
    font-size:16px;
    color:gray;
  }
  .card-panel-num{
    padding-top:10px;
    font-size:20px;
    font-weight: bold;
  }
</style>
