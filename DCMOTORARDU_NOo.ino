
int speed1;

int motor_1a = 6;// low = cw
int motor_1b = 5;
int motor_en = 13;

boolean CW = false;
boolean ACW = false;

void setup() 
{
  pinMode(motor_1a,OUTPUT);
  pinMode(motor_1b,OUTPUT);
  pinMode(motor_en,OUTPUT);
  Serial.begin(9600);
  digitalWrite(motor_en, LOW);
}

void loop() 
{
  
}

void serialEvent()
{
  speed1 = Serial.parseInt();
  if(speed1 !=0 )
  {
    if(speed1 == 1) /// CW
    {
      CW = true;
      ACW = false;
      
    }
    if(speed1 == 2)
    {
      digitalWrite(motor_en, HIGH); /// MOTOR START
      speed1=50;
    }
    if(speed1 == 3)
    {
      digitalWrite(motor_en, LOW);//// MOTOR STOP
      speed1=0;
      ACW = false;
      CW = false;
    }
    if(speed1 == 4)
    {
      ACW = true;
      CW = false;
     
    }
    if (CW && !ACW)
    {
   
      digitalWrite(motor_1a, LOW);
      analogWrite(motor_1b, speed1);
    }
    if (!CW && ACW)
    {
   
      analogWrite(motor_1a, speed1);
      digitalWrite(motor_1b, LOW);
    }
  }
  
}
