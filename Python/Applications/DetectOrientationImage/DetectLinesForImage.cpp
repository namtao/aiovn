#include<opencv2\opencv.hpp>
#include <iostream>
using namespace cv;
using namespace std;
#define ERROR 1234

//Degree conversion
double DegreeTrans(double theta)
{
 double res = theta / CV_PI * 180;
 return res;
}

//Rotate image degree angle counterclockwise (original size) 
void rotateImage(Mat src, Mat& img_rotate, double degree)
{
 //The center of rotation is the center of the image 
 Point2f center;
 center.x = float(src.cols / 2.0);
 center.y = float(src.rows / 2.0);
 int length = 0;
 length = sqrt(src.cols*src.cols + src.rows*src.rows);
 //Calculating affine transformation matrix of two dimensional rotation 
 Mat M = getRotationMatrix2D(center, degree, 1);
 warpAffine(src, img_ Rotate, m, size (length, length), 1, 0, scalar (255, 255, 255)); // affine transformation, background color is filled with white 
}

//The angle is calculated by Hough transform
double CalcDegree(const Mat &srcImage, Mat &dst)
{
 Mat midImage, dstImage;

 Canny(srcImage, midImage, 50, 200, 3);
 cvtColor(midImage, dstImage, CV_GRAY2BGR);

 //Line detection by Hough transform
 vector<Vec2f> lines;
 HoughLines(midImage, lines, 1, CV_ Pi / 180, 300, 0, 0); // the fifth parameter is the threshold. The larger the threshold, the higher the detection accuracy
 //cout << lines.size() << endl;

 //Because of the different images, the threshold is not easy to set, because the threshold is too high to detect lines, too many lines are too low, and the speed is very slow
 //Therefore, three thresholds are set according to the threshold from large to small, and a suitable threshold can be fixed after a lot of experiments.

 if (!lines.size())
 {
  HoughLines(midImage, lines, 1, CV_PI / 180, 200, 0, 0);
 }
 //cout << lines.size() << endl;

 if (!lines.size())
 {
  HoughLines(midImage, lines, 1, CV_PI / 180, 150, 0, 0);
 }
 //cout << lines.size() << endl;
 if (!lines.size())
 {
  Cout < < "no line detected! " << endl;
  return ERROR;
 }
 float sum = 0;
 //Draw each line in turn
 for (size_t i = 0; i < lines.size(); i++)
 {
  float rho = lines[i][0];
  float theta = lines[i][1];
  Point pt1, pt2;
  //cout << theta << endl;
  double a = cos(theta), b = sin(theta);
  double x0 = a*rho, y0 = b*rho;
  pt1.x = cvRound(x0 + 1000 * (-b));
  pt1.y = cvRound(y0 + 1000 * (a));
  pt2.x = cvRound(x0 - 1000 * (-b));
  pt2.y = cvRound(y0 - 1000 * (a));
  //Only the smallest angle is selected as the rotation angle
  sum += theta;
  line(dstImage, pt1, pt2, Scalar(55, 100, 195), 1, CV_ AA); // scalar function is used to adjust line segment color
  Imshow (dstimage);
 }
 float average = sum /  lines.size (); // average all angles so that the rotation effect is better
 cout << "average theta:" << average << endl;
 double angle = DegreeTrans(average) - 90;
 rotateImage(dstImage, dst, angle);
 //Imshow ("line detection effect picture 2", dstimage);
 return angle;
}

void ImageRecify(const char* pInFileName, const char* pOutFileName)
{
 double degree;
 Mat src = imread(pInFileName);
 Imshow ("original graph", SRC);
 int srcWidth, srcHight;
 srcWidth = src.cols;
 srcHight = src.rows;
 cout << srcWidth << " " << srcHight << endl;
 Mat dst;
 src.copyTo(dst);
 //Tilt angle correction
 degree = CalcDegree(src, dst);
 if (degree == ERROR)
 {
  Cout < < "correction failed! " << endl;
  return;
 }
 rotateImage(src, dst, degree);
 cout << "angle:" << degree << endl;
 Imshow ("after rotation adjustment", DST);

 Mat resulyimage = DST (Rect (0, 0, srcwidth, srcghtt)); // estimate the length and width of the text according to the prior knowledge, and then cut it out
 Imshow ("restylimage" after clipping);
 imwrite("recified.jpg", resulyImage);
}


int main()
{
 ImageRecify("jiao.jpg", "FinalImage.jpg");
 waitKey();
 return 0;
}