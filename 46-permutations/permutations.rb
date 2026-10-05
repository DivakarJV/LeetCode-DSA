def permute(nums)
  results = []
  backtrack(nums, [], results)
  results
end

def backtrack(list, temp, results)
  if temp.length == list.length
    results << temp.dup
  end
  
  list.each do |n|
    next if temp.include? n
    temp << n
    backtrack(list, temp, results)
    temp.pop
  end
end