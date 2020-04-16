import axios from 'axios'
import { Message } from 'element-ui'
import store from '@/store'
import { getToken } from '@/utils/auth'
import router from '@/router'

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API, // url = base url + request url
  withCredentials: true // send cookies when cross-domain requests
  // timeout: 25000
})

// request interceptor
service.interceptors.request.use(
  config => {
    // do something before request is sent
    var token = getToken()
    if (token) {
      config.headers['Authorization'] = token // 让每个请求携带自定义token 请根据实际情况自行修改
    }
    return config
  },
  error => {
    // do something with request error
    console.log(error) // for debug
    return Promise.reject(error)
  }
)

// response interceptor
service.interceptors.response.use(
  /**
   * If you want to get http information such as headers or status
   * Please return  response => response
  */

  /**
   * Determine the request status by custom code
   * Here is just an example
   * You can also judge the status by HTTP Status Code
   */
  response => {
    const res = response.data
    if (response.headers.token) {
      // 如果后台通过header返回token，说明token已经更新，则更新客户端本地token
      store.dispatch('user/updateToken', { token: response.headers.token })
    }
    // if the custom code is not 200, it is judged as an error.
    if (response.status !== 200 || response.statu !== 201) {
      Message({
        message: res.msg || 'error',
        type: 'error',
        duration: 5 * 1000
      })

      return Promise.reject(res)
    } else {
      return res
    }
  },
  error => {
    // 401直接返回login page，其他show message
    if (error.response.status === 401) {
      store.dispatch('user/logout').then(() => {
        router.replace({
          path: '/login',
          query: { redirect: router.currentRoute.path }
        })
      })
      return
    }
    Message({
      message: error.message,
      type: 'error',
      duration: 5 * 1000
    })
    return Promise.reject(error)
  }
)

export default service
