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
        factor= line.split(' ')
        case @p
        when 0
          @rule[factor[1]] = factor[3]
        when 1
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
          @result.push(format("%.2f",answer).to_s+" m\n")
        end
      end
    end 
    @result
  end

  def singularize(s)
    dic = {"s$" => '',"es$" => '',"ee" => 'oo'}
    return s if @rule[s]
    dic.each do |k,v|
      z = s.gsub(/#{k}/,v)
      return z if @rule[z]
    end
    s  
  end
end

@rs = Worker.new(File.open("input.txt")).run
File.new("output.txt","w").puts(@rs)
