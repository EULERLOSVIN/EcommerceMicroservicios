terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
}

provider "aws" {
  region = "us-east-1"
}

# 1. SEGURIDAD: Abrir el puerto 80 para que puedas entrar
resource "aws_security_group" "web_sg" {
  name = "pricing-service-sg"
  
  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  ingress { # SSH para conectar si hace falta
    from_port   = 22
    to_port     = 22
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# 2. SERVIDOR: Máquina gratuita (Free Tier)
resource "aws_instance" "app_server" {
  ami           = "ami-0e2c8caa4b6378d8c" # Ubuntu 24.04 en us-east-1
  instance_type = "t2.micro"              # GRATIS

  vpc_security_group_ids = [aws_security_group.web_sg.id]

  # 3. AUTOMATIZACIÓN: Esto instala Docker y arranca tu app al nacer
  user_data = <<-EOF
              #!/bin/bash
              sudo apt-get update -y
              sudo apt-get install -y docker.io
              sudo systemctl start docker
              sudo systemctl enable docker
              # Descarga tu imagen (la que subimos antes) y la corre en el puerto 80
              sudo docker run -d -p 80:8080 euler09/pricingservice:latest
              EOF

  tags = {
    Name = "PricingService-Gratis"
  }
}

output "public_ip" {
  value = aws_instance.app_server.public_ip
}