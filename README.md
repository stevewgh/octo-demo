# octo-demo
Demonstration of how to integrate a CI process with Octopus Deploy

## CI/CD flow
```mermaid
graph LR;
    A[Pull Request]-->B;
    B[GitHub Action]--  Buid, Test, Publish Image to ECR -->C;
    C[GitHub Action]-- Create OD Release -->End;
```

Test
