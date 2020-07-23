# Bootstrapping UCP cluster on AWS

This directory provides an example flow with Docker Enterprise K8s cluster provisioning with Terraform on AWS.

## Pre-requisites

* You need an account and credentials for AWS.
* Terraform [installed](https://learn.hashicorp.com/terraform/getting-started/install)

## Steps

1. Create terraform.tfvars file with needed details. You can use the provided terraform.tfvars.example as a baseline.
2. `terraform init`
3. `terraform apply`
