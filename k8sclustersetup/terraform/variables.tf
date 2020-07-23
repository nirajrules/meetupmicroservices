variable "cluster_name" {
  default = "nirajdemo"
}

variable "aws_region" {
  default = "us-east-1"
}

variable "vpc_cidr" {
  default = "172.31.0.0/16"
}

variable "admin_password" {
  default = "orcaorcaorca"
}


variable "master_count" {
  default = 3
}

variable "worker_count" {
  default = 5
}

variable "windows_worker_count" {
  default = 2
}

variable "master_type" {
  default = "m5.2xlarge"
}

variable "worker_type" {
  default = "m5.xlarge"
}

variable "master_volume_size" {
  default = 300
}

variable "worker_volume_size" {
  default = 300
}