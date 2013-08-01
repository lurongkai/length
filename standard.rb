class Worker
  def initialize(input)
    @in = input
    @p = 0
    @rule = {}
    @result = ["cd19900419@hotmail.com\n","\n"] 
  end

  def run
    @in.each do |line|
      if line == "\n"
        @p = @p + 1
      else
        case @p
        when 0
          factor= line.split(' ')
          @rule[factor[1]] = factor[3]
        when 1
          factor = line.split(" ")
          if (line.include? '+') || (line.include? '-')
            equation = []
            factor.each_with_index do |array,index|
              if array == '+' || array == '-'
                equation.push(array)
              elsif !(array =~ /^[a-z]+$/)
                unit = singularize(factor[index+1])
                equation.push( array.to_f * @rule[unit].to_f)
              end
            end
             answer = eval(equation.join)
          else
            unit = singularize(factor[1])
            answer = factor[0].to_f * @rule[unit].to_f
          end
          answer = format("%.2f",answer)
          @result.push(answer.to_s+" m\n")
        end
      end
    end 
  @result
  end

  def singularize(s)
    return s if @rule[s]
    z = s.gsub(/s$/,'')
    return z if @rule[z]
    z = s.gsub(/es$/,'') 
    return z if @rule[z]
    z = s.gsub(/ee/,'oo')
    return z if @rule[z]
    s  
  end

end

new_work = Worker.new(File.open("input.txt"))
@rs = new_work.run
file = File.new("output.txt","w")
file.puts(@rs)
