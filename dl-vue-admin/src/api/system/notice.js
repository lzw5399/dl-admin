import request from '@/utils/request'

export function getList(params) {
  return request({
    url: 'api/notice/list',
    method: 'get',
    params
  })
}
