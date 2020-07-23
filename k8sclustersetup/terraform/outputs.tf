resource "local_file" "ansibleinventory_yml" {
  
  content  = templatefile("./templates/ansibleyml.tmpl",
  {
    k8s_leader = "${format("%s:", element(module.masters.machines, 0).public_ip)}",
    k8s_managers = "${format("%s:\n        %s:",element(module.masters.machines, 1).public_ip,element(module.masters.machines, 2).public_ip)}",
    k8s_workers = "${format("%s:\n            %s:",element(module.workers.machines, 3).public_ip,element(module.workers.machines, 4).public_ip)}",
    k8s_dtrprimary = "${format("%s:", element(module.workers.machines, 0).public_ip)}",
    k8s_dtrsecondary = "${format("%s:\n            %s:",element(module.workers.machines, 1).public_ip,element(module.workers.machines, 2).public_ip)}",
    k8s_windowsworkers = "${format("%s:\n            %s:",element(module.windows_workers.machines, 0).public_ip,element(module.windows_workers.machines, 1).public_ip)}"
    key_path = "../terraform/ssh_keys/${var.cluster_name}.pem",
    ssh_user = "ec2-user",
    # k8s_master_name = "${join(":\n        ", module.masters.machines.*.public_ip)}",
    # k8s_linuxworkers_name = "${join(":\n        ", module.workers.machines.*.public_ip)}",
    # k8s_dtrworkers_name = "${join(":\n        ", module.workers.machines.*.public_ip)}",
    # k8s_windowsworkers_name = "${join(":\n        ", module.windows_workers.machines.*.public_ip)}"
  }
  )
  filename = "../ansible/ansibleinventory.yml"
}

resource "local_file" "hosts" {
  content  = templatefile("./templates/hosts.tmpl",
  {
    master0 = element(module.masters.machines, 0).public_ip,
    master1 = element(module.masters.machines, 1).public_ip,
    master2 = element(module.masters.machines, 2).public_ip,
    dtr0 = element(module.workers.machines, 0).public_ip,
    dtr1 = element(module.workers.machines, 1).public_ip,
    dtr2 = element(module.workers.machines, 2).public_ip,
    dtr3 = element(module.workers.machines, 3).public_ip,
    dtr4 = element(module.workers.machines, 4).public_ip
  }
  )
  filename = "../ansible/hosts"
}

