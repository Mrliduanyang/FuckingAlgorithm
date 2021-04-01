public class Solution {
    public int ReversePairs(int[] nums) {
         
            if (nums.Length==0)
            {
                //没有元素，返回0
                return 0;
            }
             return mergSort(nums,0,nums.Length-1);
        }
        //对当前的序列进行归并排序
        private int mergSort(int[] nums,int start,int end)
        {
            if (start==end)
            {
                //不在构成序列，返回递归的出口
                return 0;
            }
            int mid = (start + end)/2 ;//中点
            int n1 = mergSort(nums,start,mid);//左序列归并排序
            int n2 = mergSort(nums,mid+1,end);//右序列归并排序
            int ret = n1 + n2;
            //此时左右序列都已经排序，现在合并，以及合并前的统计
            int i = start;//i指向左序列的开头
            int j = mid + 1;//j指向有序列的开头
            while (i<=mid)
            {
                while (j<=end&&(long)nums[i]>2*(long)nums[j])
                {
                    j++;
                }
                ret += j - mid - 1;
                i++;
            }
            //合并两个排序数组
            int[] sortnum = new int[end-start+ 1];
            int p1 = start, p2 = mid + 1;
            int p = 0;
            while (p1<=mid||p2<=end)
            {
                if (p1>mid)
                {
                    sortnum[p++] = nums[p2++];
                }else if (p2 > end)
                {
                    sortnum[p++] = nums[p1++];
                }
                else
                {
                    if (nums[p1]<nums[p2])
                    {
                        sortnum[p++] = nums[p1++];
                    }
                    else
                    {
                        sortnum[p++] = nums[p2++];
                    }
                }
            }
            for (int n = 0; n < sortnum.Length; n++)
            {
                nums[start + n] = sortnum[n];
            }
            return ret;


        }
    
}
