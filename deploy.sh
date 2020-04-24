# 进入docker-compose.yml文件的文件夹，$1代表外部传入的参数
echo -e "\033[36m start deploying... \033[0m"
cd $1

# pull newest image
echo -e "\033[36m step1: pull newest image \033[0m"
sudo docker-compose pull >> /dev/null 2>&1
if [[ $? != 0 ]]; then
  exit 0
fi

# beaucuse we doesn't need build image in server, so doesn't need "--build"
echo -e "\033[36m step2: recreating container \033[0m"
sudo docker-compose up --force-recreate -d >> /dev/null 2>&1
if [[ $? != 0 ]]; then
  exit 0
fi

# remove dangling images
echo -e "\033[36m step3: remove dangling images \033[0m"
danglings=$(sudo docker images -f "dangling=true" -q)
if test -n "$danglings"; then
  sudo docker rmi $(sudo docker images -f "dangling=true" -q) >>/dev/null 2>&1
  if [[ $? != 0 ]]; then
    echo 'failed to remove danglings container...'
    exit $?
  fi
fi

echo -e "\033[36m done! \033[0m"
