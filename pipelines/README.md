# Tekton Overview

Steps => Tasks => Pipelines

PipelineResources => PipelineRuns <= Pipelines

Tekton Pipelines is an OpenSource project by Google to Build, Run and Maintain CI/CD pipelines for Kubernetes Apps and provides k8s-style resources declaration for CI/CD-style pipelines. Tekton Pipelines are built using Kubernetes CRD’s, it is based on Operator model.

Steps are fundamental blocks of Pipelines. A step is actually an instance of an image and it is Kubernetes container spec. step contains the actual work to be done.

Tasks contain a series of steps to be executed in sequential order on the same node, so they can share resources i.e. output/artifacts/parameters of one step to another. Tasks can exist and be invoked completely independently of Pipelines; they are highly cohesive and loosely coupled. Tasks can be invoked via TaskRuns

Pipelines lets you put together the tasks, so they can run concurrently/Sequentially. They are not guaranteed to execute on the same node, it depends on K8S’s scheduling of pods. But you can have inputs for one task that come from the output of another task, which is specified in the pipeline. They can be triggered by events or by manually creating PipelineRuns

Pipelines and tasks are declared once and they are used again and again. We create TaskRuns and PipelineRuns to invoke Tasks and PipelineRuns.

PipelineResources are the artifacts used as inputs and outputs of Tasks.

## Setup Tekton CLI (on macOS)

```bash
brew tap tektoncd/tools
brew install tektoncd/tools/tektoncd-cli
```

Usage: tkn &lt;resourcetype&gt; &lt;command&gt; &lt;args&gt;
Example: tkn pipelinerun logs --last -f

## Run Pipelines

Leverage the generateName metadata rather the name

```yml
metadata:
 generateName: meetup-pipeline-run-
```

The resource should be created (create command: kubectl create -f meetuppipelinerun.yml) and not applied, as apply generates an error as the name is missing. You can run the create command multiple times and would see a unqiue suffix generated everytime

```bash
tkn pipelinerun ls
NAME                                          STARTED          DURATION     STATUS
meetup-pipeline-run-jk5q5                     6 minutes ago    52 seconds   Succeeded
meetup-pipeline-run-gm4xz                     26 minutes ago   50 seconds   Succeeded
```

## Triggers

### EventListener

This is the public facing part of Tekton Triggers. An EventListener sets up a Kubernetes Service which is exposed via Istio Gateway. The Webhook in the GitHub repo will invoke the eventlistener on specific events like Push, Pull Request, etc. The webhook creation for GitHub has been automated as task (See githubwebhooktask.yml and githubwebhooktaskrun.yml) EventListener connects TriggerTemplates to TriggerBindings which are executed as a response to event.

### TriggerTemplate

TriggerTemplate defines a Template for how a Pipeline should be run in reaction to events. It's the replacement for manual PipelineRun invocation. It will provide pipeline resources and service account required to run the pipeline.

### TriggerBinding

TriggerBinding specifies the mapping (binding) between event payloads received by the EventListener and parameters specified in a TriggerTemplate.

### Expose EventListener

To allow EventListener service to be invoked by Github Webhook, the service is exposed via Istio Ingress Gateway

## Links & References

<https://medium.com/@jerome_tarte/additional-tekton-tips-for-your-pipelines-7dd662140e8f>
<https://medium.com/@nikhilthomas1/cloud-native-cicd-on-openshift-with-openshift-pipelines-tektoncd-pipelines-part-3-github-1db6dd8e8ca7>
<https://medium.com/ibm-garage/fun-with-gitops-stitching-kubernetes-tekton-and-argo-ee348afd0b08>
