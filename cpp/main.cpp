#include <opencv2/opencv.hpp>
#include <vector>
#include <windows.h>

extern "C" __declspec(dllexport) int DetectMobs(
    unsigned char* imageData,
    int width,
    int height,
    int* outBuffer,
    int bufferSize)
{
    try {
        cv::Mat src = cv::Mat(height, width, CV_8UC4, imageData).clone();
        cv::Mat gray, delta, thresh;
        static cv::Mat prevGray;

        cvtColor(src, gray, cv::COLOR_BGRA2GRAY);
        GaussianBlur(gray, gray, cv::Size(11, 11), 0);

        if (prevGray.empty()) {
            gray.copyTo(prevGray);
            return 0;
        }

        absdiff(prevGray, gray, delta);
        threshold(delta, thresh, 25, 255, cv::THRESH_BINARY);
        dilate(thresh, thresh, cv::noArray());

        std::vector<std::vector<cv::Point>> contours;
        findContours(thresh, contours, cv::RETR_EXTERNAL, cv::CHAIN_APPROX_SIMPLE);

        int count = 0;
        cv::Point center(width / 2, height / 2);

        for (auto& cnt : contours) {
            double area = contourArea(cnt);
            if (area > 500 && count * 4 < bufferSize) {
                cv::Rect r = boundingRect(cnt);
                outBuffer[count * 4 + 0] = r.x;
                outBuffer[count * 4 + 1] = r.y;
                outBuffer[count * 4 + 2] = r.width;
                outBuffer[count * 4 + 3] = r.height;
                count++;
            }
        }

        prevGray = gray;
        return count;
    } catch (...) {
        return -1;
    }
}
