import request from '@/utils/request'

export function tree() {
  return request({
    url: 'api/dept/tree',
    method: 'get'
  })
}

export function list() {
  return request({
    url: 'api/dept/list',
    method: 'get'
  })
}

export function save(params) {
  return request({
    url: 'api/dept',
    method: 'post',
    params: params
  })
}

export function del(id) {
  return request({
    url: 'api/dept',
    method: 'delete',
    params: {
      id: id
    }
  })
}
