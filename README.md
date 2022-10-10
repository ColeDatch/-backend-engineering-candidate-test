# How to use

This template aims to bootstrap you so that you can deploy and test your serverless APIs without having to first learn all of the AWS Serverless tooling.

Deployment will be done via command line. You are expected to replace parts of this project to help us identify you and to help you test your APIs.

# Setting up

## Install tools

1. Create an AWS account or use an existing AWS account for testing https://aws.amazon.com/
   1. The specific account you use isn't important
1. dotnet CLI https://docs.microsoft.com/en-us/dotnet/core/install/sdk
1. AWS extensions for dotnet CLI https://github.com/aws/aws-extensions-for-dotnet-cli#installing-extensions
1. AWS CLI https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-install.html

## Configure tools

1. Configure the AWS CLI credentials using https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-files.html

## Create an S3 bucket to host deployment artifacts

1. Log in to your AWS account
1. Go to the [S3 management page](https://s3.console.aws.amazon.com/s3/home?region=us-west-1#)
1. Create a bucket
1. Use any bucket name that works. The only important thing here is that you will use this name to update your deployment config.
1. Use default settings for the bucket

## Update deployment config

Find the three lines which contain the word "**example**" in [aws-lambda-tools-defaults.json](./aws-lambda-tools-defaults.json) and replace them with your name in dash case.

For instance, if your name is Terry Bogard, the relevant part of your config should look like this

```json
  "stack-name": "terry-bogard-sd-backend-engineering-test",
  "s3-bucket": "<artifact-bucket-name-from-last-step>",
  "s3-prefix": "terry-bogard",
```

## Verify deployment

1. Open a command line
1. cd to this directory
1. Run ```dotnet lambda deploy-serverless```

You should see output similar to the following

```
Amazon Lambda Tools for .NET Core applications (4.0.0)
Project Home: https://github.com/aws/aws-extensions-for-dotnet-cli, https://github.com/aws/aws-lambda-dotnet

Processing CloudFormation resource TicTacToeApi
Processing CloudFormation resource SayHelloFunction

...REMOVED FOR BREVITY!...

Created CloudFormation stack example-sd-backend-engineering-test

Timestamp            Logical Resource Id                      Status
-------------------- ---------------------------------------- ----------------------------------------
6/17/2020 2:09 PM    example-sd-backend-engineering-test      CREATE_IN_PROGRESS
6/17/2020 2:09 PM    SayHelloFunctionRole                     CREATE_IN_PROGRESS
6/17/2020 2:09 PM    SayHelloFunctionRole                     CREATE_COMPLETE
6/17/2020 2:09 PM    SayHelloFunction                         CREATE_IN_PROGRESS
6/17/2020 2:09 PM    SayHelloFunction                         CREATE_COMPLETE
6/17/2020 2:09 PM    TicTacToeApi                             CREATE_IN_PROGRESS
6/17/2020 2:09 PM    TicTacToeApi                             CREATE_COMPLETE
6/17/2020 2:09 PM    SayHelloFunctionGetHelloPermissionProd   CREATE_IN_PROGRESS
6/17/2020 2:09 PM    TicTacToeApiDeployment675a325936         CREATE_IN_PROGRESS
6/17/2020 2:09 PM    TicTacToeApiDeployment675a325936         CREATE_COMPLETE
6/17/2020 2:09 PM    TicTacToeApiProdStage                    CREATE_IN_PROGRESS
6/17/2020 2:09 PM    TicTacToeApiProdStage                    CREATE_COMPLETE
6/17/2020 2:09 PM    SayHelloFunctionGetHelloPermissionProd   CREATE_COMPLETE
6/17/2020 2:09 PM    example-sd-backend-engineering-test      CREATE_COMPLETE
Stack finished updating with status: CREATE_COMPLETE

Output Name                    Value
------------------------------ --------------------------------------------------
ApiURL                         https://drxtrjpmw8.execute-api.us-west-1.amazonaws.com/Prod/
```

## Verify the endpoint

What you just deployed was a functioning API endpoint, with only one route.

In the above output, the endpoint URL is `https://drxtrjpmw8.execute-api.us-west-1.amazonaws.com/Prod` and the route is `/hello` so our actual URL becomes https://drxtrjpmw8.execute-api.us-west-1.amazonaws.com/Prod/hello

Test the endpoint using your API tester of choice (browser, curl, postman, etc)

# What to do next

At this point, you have a working, deployable serverless application.

From here, your task is to fulfill the requirements in the test email by adding API handlers to [serverless.template](./serverless.template) and backing code to [Function.cs](./Function.cs)

You can redeploy changes you make by running the command you ran earlier: ```dotnet lambda deploy-serverless```
