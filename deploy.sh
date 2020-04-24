# 进入docker-compose.yml文件的文件夹，$1代表外部传入的参数
cd $1

# pull newest image
sudo docker-compose pull >> /dev/null 2>&1
if [[ $? != 0 ]]; then
  exit 0
fi

# beaucuse we doesn't need build image in server, so doesn't need "--build"
sudo docker-compose up --force-recreate -d >> /dev/null 2>&1
if [[ $? != 0 ]]; then
  exit 0
fi

# remove dangling images
danglings=$(sudo docker images -f "dangling=true" -q)
if test -n "$danglings"; then
  sudo docker rmi $(sudo docker images -f "dangling=true" -q) >>/dev/null 2>&1
  if [[ $? != 0 ]]; then
    echo 'failed to remove danglings container...'
    exit $?
  fi
fi
